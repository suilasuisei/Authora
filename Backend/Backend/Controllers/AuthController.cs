using Backend.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Auth.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly TestDBContext _dbContext;

        public AuthController(TestDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("google")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = "/api/google-callback"
            };

            return Challenge(
                properties,
                GoogleDefaults.AuthenticationScheme
            );
        }

        [HttpGet("google-callback")]
        public async Task<IActionResult> GoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync();

            if (!result.Succeeded)
            {
                return BadRequest("Google 登入失敗");
            }

            // Google Email
            var email = result.Principal?
                .FindFirst(ClaimTypes.Email)?.Value;

            // Google 使用者名稱
            var name = result.Principal?
                .FindFirst(ClaimTypes.Name)?.Value;

            // Google 使用者 ID
            var googleId = result.Principal?
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("無法取得 Google Email");
            }

            if (string.IsNullOrEmpty(googleId))
            {
                return BadRequest("無法取得 Google ID");
            }

            // 查詢是否已經有這個 Google 帳號
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.GoogleId == googleId);

            // 如果沒有，就建立新使用者
            if (user == null)
            {
                user = new Users
                {
                    Account = email,
                    Password = null,
                    UserName = name ?? "Google User",
                    UserStatus = "Enable",
                    LoginType = "Google",
                    GoogleId = googleId,
                    CreatDate = DateTime.UtcNow,
                    UpdateDate = null
                };

                _dbContext.Users.Add(user);

                await _dbContext.SaveChangesAsync();
            }

            // 導向 Next.js
            return Redirect("http://localhost:3000/");
        }
    }
}
