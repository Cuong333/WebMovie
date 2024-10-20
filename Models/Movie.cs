using System;

namespace WebMovie.Models
{
	public partial class Movie
	{
		public int MovieId { get; set; }

		public string? Title { get; set; }

		public string? Description { get; set; }

		public DateOnly? ReleaseDate { get; set; } // Sử dụng ReleaseDate thay cho Released

		public int? Duration { get; set; } // Sử dụng Duration thay cho Runtime

		public int? GenreId { get; set; }

		public int? DirectorId { get; set; }

		public string Rated { get; set; }

		public string Plot { get; set; }

		public string Poster { get; set; }
	}
}
