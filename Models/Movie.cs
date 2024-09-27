using System;
using System.Collections.Generic;

namespace WebMovie.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public int? Duration { get; set; }

    public int? GenreId { get; set; }

    public int? DirectorId { get; set; }
}
