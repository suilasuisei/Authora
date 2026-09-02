namespace Backend.Models.Params
{
    public class CreatuserParam
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public required string Account { get; set; } 

        /// <summary>
        /// 密碼
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public required string UserName { get; set; } 

    }
}
