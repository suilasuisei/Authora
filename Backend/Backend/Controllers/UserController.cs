using AutoMapper;
using Backend.Models.Dtos;
using Backend.Models.Params;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(
            IUserService userService,
            IMapper mapper
        )
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// 使用者註冊
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Register")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreatuserParam request)
        {
            
            var Dto = _mapper.Map<CreateUserDto>(request);

            await _userService.RegisterUserAsync(Dto);

            return Ok("已註冊成功");
        }

        /// <summary>
        /// 使用者名稱查詢
        /// </summary>
        /// <param name="acc">帳號</param>
        /// <returns></returns>
        
        
        [HttpGet("{acc}")]
        public async Task<IActionResult> SearchUserAsync([FromRoute] SearchuserParam acc)
        {
            var Dto = _mapper.Map<SearchUserDto>(acc);

            var user = await _userService.SearchUserAsync(Dto);

            if (user == null)
            {
                return NotFound("查無使用者");
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
            var user = await _userService.RemoveUserAsync(removeacc);

            if (user == null)
            {
                return NotFound("未檢測到帳號");
            }

            return Ok("已刪除成功");
        }
    }
}
