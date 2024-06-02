using System;
using System.Collections.Generic;

namespace FishingForumApi2.Repository.FishingForum;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SubCategory> SubCategory { get; set; } = new List<SubCategory>();
}
