namespace Backend.Models.Dtos
{
    public class CreateUserDto
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 使用者狀態
        /// </summary>
        public string UserStatus { get; set; } = "Enable";

        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTime? CreatDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        public string LoginType { get; set; } = "Normal";

        public string GoogleId { get; set; } = string.Empty ;
    }
}
