using Backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TestDBContext _dbContext;

        public UserController(TestDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 使用者註冊
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] Users request)
        {
            var isOld = await _dbContext.Users.AnyAsync(user => user.Account == request.Account);

            if (isOld)
            {
                return BadRequest("帳號已被使用");
            }
            await _dbContext.Users.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return Ok("已註冊成功");
        }

        /// <summary>
        /// 使用者名稱查詢
        /// </summary>
        /// <param name="acc">帳號</param>
        /// <returns></returns>
        [HttpGet("{acc}")]
        public async Task<IActionResult> SearchUsernameAsync([FromRoute]string acc)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Account == acc);
            if (user == null) 
            {
                return NotFound("未發現使用者名稱");
            }
            return Ok(user);
        }


        /// <summary>
        /// 使用者資料刪除
        /// </summary>
        /// <param name="removeacc"></param>
        /// <returns></returns>
        [HttpDelete("{removeacc}")]
        public async Task<IActionResult> RemoveUserAsync([FromRoute] string removeacc )
        { 
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName == removeacc);
            if (user == null) 
            {
                return NotFound("未檢測到帳號");
            }
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return Ok("已刪除成功");
        }
    }
}
