using System;
using System.Collections.Generic;

namespace FishingForumApi2.Repository.FishingForum;

public partial class ForumPicture
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public int Width { get; set; }

    public int Height { get; set; }
}
