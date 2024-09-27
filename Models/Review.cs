using System;
using System.Collections.Generic;

namespace WebMovie.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? UserId { get; set; }

    public int? MovieId { get; set; }

    public string? Content { get; set; }

    public string? Rating { get; set; }
}
