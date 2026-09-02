namespace Backend.Models.Entities;

public partial class Users
{
    /// <summary>
    /// 帳號
    /// </summary>
    public string Account { get; set; } = null!;

    /// <summary>
    /// 密碼
    /// </summary>
    public string? Password { get; set; } 

    /// <summary>
    /// 使用者名稱
    /// </summary>
    public string UserName { get; set; } = null!;

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

    public string? LoginType { get; set; }

    public string? GoogleId { get; set; }

    public string LineId { get; set; } = null!;
    public string? DisplayName { get; set; }
    public string? Email { get; set; }
    public string? PictureUrl { get; set; }
}
