using System;
using System.Collections.Generic;

namespace FishingForumApi2.Repository.FishingForum;

public partial class Message
{
    public Guid Id { get; set; }

    public DateTime DateCreated { get; set; }

    public string Text { get; set; } = null!;

    public string SenderId { get; set; } = null!;

    public string RecieverId { get; set; } = null!;
}
