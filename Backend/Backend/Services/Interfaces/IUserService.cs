using Backend.Models.Dtos;
using Backend.Models.Entities;

namespace Backend.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 使用者註冊
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        Task RegisterUserAsync(CreateUserDto Dto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Keyword"></param>
        /// <returns></returns>
        Task<Users?> SearchUserAsync(SearchUserDto Keyword);

        /// <summary>
        /// 使用者刪除
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        Task<Users?> RemoveUserAsync(string UserName);

        /// <summary>
        /// Line登入
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<UserDto> LineLoginAsync(string code);
    }
}
