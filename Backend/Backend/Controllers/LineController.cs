using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _0806.Controllers
{
    public class LineController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public LineController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }


        [HttpGet("line")]
        public IActionResult LineLogin()
        {
            var channelId =
                _configuration["LineLogin:ChannelId"];

            var redirectUri =
                _configuration["LineLogin:RedirectUri"];

            var url =
                "https://access.line.me/oauth2/v2.1/authorize" +
                $"?response_type=code" +
                $"&client_id={channelId}" +
                $"&redirect_uri={Uri.EscapeDataString(redirectUri!)}" +
                $"&scope=profile%20openid" +
                $"&state=123456";

            return Redirect(url);
        }

        [HttpGet("line-callback")]
        public async Task<IActionResult> LineCallback(
            string code,
            string state
            )
        {
            await _userService.LineLoginAsync(code);

            // 導向 Next.js
            return Redirect("http://localhost:3000/");
        }

    }
}
