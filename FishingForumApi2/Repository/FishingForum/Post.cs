using System;
using System.Collections.Generic;

namespace FishingForumApi2.Repository.FishingForum;

public partial class Post
{
    public Guid Id { get; set; }

    public DateTime DateCreated { get; set; }

    public string Text { get; set; } = null!;

    public Guid ThreadId { get; set; }

    public string UserId { get; set; } = null!;

    public bool Reported { get; set; }

    public virtual Thread Thread { get; set; } = null!;

    public virtual AspNetUsers User { get; set; } = null!;

    public virtual ICollection<UserPicture> UserPicture { get; set; } = new List<UserPicture>();
}
