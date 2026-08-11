using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models.Entities;

public partial class TestDBContext : DbContext
{
    public TestDBContext(DbContextOptions<TestDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Account);

            entity.Property(e => e.Account)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("帳號");
            entity.Property(e => e.CreatDate)
                .HasComment("創建時間")
                .HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("密碼");
            entity.Property(e => e.UpdateDate)
                .HasComment("更新時間")
                .HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(10)
                .HasComment("使用者名稱");
            entity.Property(e => e.UserStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("使用者狀態");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
