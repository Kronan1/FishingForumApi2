using System;
using System.Collections.Generic;

namespace FishingForumApi2.Repository.FishingForum;

public partial class AspNetUsers
{
    public string Id { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; } = new List<AspNetUserClaims>();

    public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; } = new List<AspNetUserLogins>();

    public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; } = new List<AspNetUserTokens>();

    public virtual ICollection<Post> Post { get; set; } = new List<Post>();

    public virtual ICollection<Thread> Thread { get; set; } = new List<Thread>();

    public virtual ICollection<UserPicture> UserPicture { get; set; } = new List<UserPicture>();

    public virtual ICollection<AspNetRoles> Role { get; set; } = new List<AspNetRoles>();
}
