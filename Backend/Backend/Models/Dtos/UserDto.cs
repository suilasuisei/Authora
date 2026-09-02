namespace Backend.Models.Dtos
{
    public class UserDto
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 使用者狀態
        /// </summary>
        public string UserStatus { get; set; } = string.Empty;

        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTime? CreatDate { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        public string? LoginType { get; set; }

        public string? GoogleId { get; set; }

        public string? LineId { get; set; }

        public string? DisplayName { get; set; }

        public string? Email { get; set; }

        public string? PictureUrl { get; set; }
    }
}
