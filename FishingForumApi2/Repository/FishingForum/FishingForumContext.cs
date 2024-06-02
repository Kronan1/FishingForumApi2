using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FishingForumApi2.Repository.FishingForum;

public partial class FishingForumContext : DbContext
{
    public FishingForumContext(DbContextOptions<FishingForumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }

    public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<ForumPicture> ForumPicture { get; set; }

    public virtual DbSet<Message> Message { get; set; }

    public virtual DbSet<Post> Post { get; set; }

    public virtual DbSet<SubCategory> SubCategory { get; set; }

    public virtual DbSet<Thread> Thread { get; set; }

    public virtual DbSet<UserPicture> UserPicture { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRoleClaims>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetRoles>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUserClaims>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogins>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserTokens>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUsers>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Role).WithMany(p => p.User)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRoles",
                    r => r.HasOne<AspNetRoles>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUsers>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasIndex(e => e.ThreadId, "IX_Post_ThreadId");

            entity.HasIndex(e => e.UserId, "IX_Post_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Thread).WithMany(p => p.Post)
                .HasForeignKey(d => d.ThreadId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Post)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.UserPicture).WithMany(p => p.Post)
                .UsingEntity<Dictionary<string, object>>(
                    "PostUserPicture",
                    r => r.HasOne<UserPicture>().WithMany().HasForeignKey("UserPictureId"),
                    l => l.HasOne<Post>().WithMany().HasForeignKey("PostId"),
                    j =>
                    {
                        j.HasKey("PostId", "UserPictureId");
                        j.HasIndex(new[] { "UserPictureId" }, "IX_PostUserPicture_UserPictureId");
                    });
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_SubCategory_CategoryId");

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategory).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<Thread>(entity =>
        {
            entity.HasIndex(e => e.SubCategoryId, "IX_Thread_SubCategoryId");

            entity.HasIndex(e => e.UserId, "IX_Thread_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.SubCategory).WithMany(p => p.Thread).HasForeignKey(d => d.SubCategoryId);

            entity.HasOne(d => d.User).WithMany(p => p.Thread).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserPicture>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_UserPicture_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.FileName).HasMaxLength(36);
            entity.Property(e => e.FileType).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.UserPicture).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
