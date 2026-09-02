namespace Backend.Models.Params
{
    public class SearchuserParam
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public required string Account { get; set; }


        /// <summary>
        /// 使用者名稱
        /// </summary>
        public required string UserName { get; set; }
    }
}
