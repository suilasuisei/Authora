namespace Backend.Models.Dtos
{
    public class SearchUserDto
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; } = string.Empty;


        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; } = string.Empty;
    }
}
