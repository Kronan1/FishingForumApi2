using System;
using System.Collections.Generic;

namespace FishingForumApi2.Repository.FishingForum;

public partial class UserPicture
{
    public Guid Id { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public virtual AspNetUsers User { get; set; } = null!;

    public virtual ICollection<Post> Post { get; set; } = new List<Post>();
}
