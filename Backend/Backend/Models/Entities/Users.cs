using System;
using System.Collections.Generic;

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
    public string Password { get; set; } = null!;

    /// <summary>
    /// 使用者名稱
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    /// 使用者狀態
    /// </summary>
    public string? UserStatus { get; set; } = "Enable";

    /// <summary>
    /// 創建時間
    /// </summary>
    public DateTime? CreatDate { get; set; } = DateTime.UtcNow; // Utc標準時間

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime? UpdateDate { get; set; }
}
