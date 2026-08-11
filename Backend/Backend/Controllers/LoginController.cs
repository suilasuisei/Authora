using Backend.Models;
using Backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TestDBContext _dbContext;


        public LoginController(TestDBContext dbContext)
        {  
            _dbContext = dbContext;
        }


        /// <summary>
        /// 使用者登入
        /// </summary>
        /// <param name="useracc"></param>
        /// <returns></returns>
        [HttpPost]

        public async Task<IActionResult> UserLogin([FromBody]LoginParam request) 
        {
            var user = await _dbContext.Users.AnyAsync(user => user.Account == request.Account && user.Password == request.Password);
            if (user == false)
            {
                return BadRequest("帳號或密碼錯誤");
            }
            return Ok("登入成功");
        }
    }
}
