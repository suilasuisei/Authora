using AutoMapper;
using Backend.Models.Dtos;
using Backend.Models.Entities;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepo _usersRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        

        public UserService(
            IUsersRepo usersRepo,
            IMapper mapper,
            IConfiguration configuration,
            HttpClient httpClient
        )
        {

            _usersRepo = usersRepo;
            _mapper = mapper;
            _configuration = configuration;
            _httpClient = httpClient;

        }

        public async Task RegisterUserAsync(CreateUserDto Dto)
        {
            var isOld = await _usersRepo.ExistUserAsync(Dto.Account);

            if (isOld)
            {
                throw new Exception("帳號已被使用");
            }

            

            var user = _mapper.Map<Users>(Dto);

            await _usersRepo.CreateUserAsync(user);
        }

        public async Task<Users?> SearchUserAsync(SearchUserDto Keyword)
        {
            var keyword = !string.IsNullOrEmpty(Keyword.Account) ? Keyword.Account : Keyword.UserName;

            return await _usersRepo.SearchUserAsync(keyword);
        }

        public async Task<Users?> RemoveUserAsync(string UserName)
        {
            return await _usersRepo.RemoveUserAsync(UserName);
        }

        public async Task<UserDto> LineLoginAsync(string code)
        {
            // 1. 取得 LINE 設定
            var channelId =
                _configuration["LineLogin:ChannelId"];

            var channelSecret =
                _configuration["LineLogin:ChannelSecret"];

            var redirectUri =
                _configuration["LineLogin:RedirectUri"];

            // 2. 用 code 向 LINE 換 Token
            var tokenRequestBody = new Dictionary<string, string>
            {
                ["grant_type"] = "authorization_code",
                ["code"] = code,
                ["redirect_uri"] = redirectUri!,
                ["client_id"] = channelId!,
                ["client_secret"] = channelSecret!,
            };

            var tokenHttpResponse = await _httpClient.PostAsync(
                "https://api.line.me/oauth2/v2.1/token",
                new FormUrlEncodedContent(tokenRequestBody)
            );

            tokenHttpResponse.EnsureSuccessStatusCode();

            var tokenResult =
                await tokenHttpResponse.Content.ReadFromJsonAsync<LineTokenResponseDto>()
                ?? throw new Exception("換取 LINE Token 失敗");

            // 3. 驗證 ID Token
            var idTokenPayload = ParseLineIdToken(
                tokenResult.IdToken ?? throw new Exception("LINE 未回傳 ID Token")
            );

            // 4. 取得 LineId
            var lineId = idTokenPayload.Sub;
            var displayName = idTokenPayload.Name;

            // 5. 查詢資料庫
            var user =
                await _usersRepo.GetByLineIdAsync(lineId);

            // 6. 如果沒有使用者
            if (user == null)
            {
                user = new Users
                {
                    Account = lineId,
                    UserName = displayName ?? lineId,
                    LineId = lineId,
                    DisplayName = displayName,
                    Email = idTokenPayload.Email,
                    PictureUrl = idTokenPayload.Picture,
                    LoginType = "LINE",
                    UserStatus = "Enable",
                    CreatDate = DateTime.Now
                };

                user = await _usersRepo.CreateUserAsync(user);
            }

            return _mapper.Map<UserDto>(user);
        }

        /// <summary>
        /// 解析 LINE ID Token（JWT）的 payload，取得使用者資料
        /// 註：此處僅解碼 payload，未驗證簽章，正式環境應改用 LINE 的 JWK 驗證簽章
        /// </summary>
        private static LineIdTokenPayloadDto ParseLineIdToken(string idToken)
        {
            var parts = idToken.Split('.');

            if (parts.Length != 3)
            {
                throw new Exception("LINE ID Token 格式錯誤");
            }

            var payloadJson = Base64UrlDecode(parts[1]);

            return JsonSerializer.Deserialize<LineIdTokenPayloadDto>(payloadJson)
                ?? throw new Exception("解析 LINE ID Token 失敗");
        }

        private static string Base64UrlDecode(string input)
        {
            var base64 = input.Replace('-', '+').Replace('_', '/');

            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
    }
}
