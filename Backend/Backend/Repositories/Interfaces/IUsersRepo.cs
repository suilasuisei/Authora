using Backend.Models.Entities;

namespace Backend.Repositories.Interfaces
{
    public interface IUsersRepo
    {
        /// <summary>
        /// 查詢使用者是否存在
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        Task<bool> ExistUserAsync(string Account);

        /// <summary>
        /// 創建使用者
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Users> CreateUserAsync(Users user);

        /// <summary>
        /// 搜尋使用者
        /// </summary>
        /// <param name="Keyword"></param>
        /// <returns></returns>
        Task<Users?> SearchUserAsync(string Keyword);

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        Task<Users?> RemoveUserAsync(string UserName);

        /// <summary>
        /// 讀取LineId
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        Task<Users?> GetByLineIdAsync(string lineId);

    }


}
