using System;
using System.Collections.Generic;

namespace WebMovie.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? MovieId { get; set; }

    public int? UserId { get; set; }

    public string? Comment1 { get; set; }

    public string? TimeStamp { get; set; }
}
