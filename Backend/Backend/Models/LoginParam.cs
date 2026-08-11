namespace Backend.Models
{
    /// <summary>
    /// 登入參數
    /// </summary>
    public class LoginParam
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public required string Password { get; set; }
    }
}
