using System;
using System.Collections.Generic;

namespace FishingForumApi2.Repository.FishingForum;

public partial class SubCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Thread> Thread { get; set; } = new List<Thread>();
}
