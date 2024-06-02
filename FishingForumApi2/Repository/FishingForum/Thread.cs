using System;
using System.Collections.Generic;

namespace FishingForumApi2.Repository.FishingForum;

public partial class Thread
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public int SubCategoryId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public virtual ICollection<Post> Post { get; set; } = new List<Post>();

    public virtual SubCategory SubCategory { get; set; } = null!;

    public virtual AspNetUsers User { get; set; } = null!;
}
