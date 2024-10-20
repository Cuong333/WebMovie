using Microsoft.AspNetCore.Mvc;
using WebMovie.Models;
public class MovieController : Controller
{
	MovieContext db = new MovieContext();
	private MovieService _movieService = new MovieService();

	public ActionResult Index()
	{
		return View();
	}

	[HttpPost]
	public async Task<ActionResult> Search(string title)
	{
		if (!string.IsNullOrEmpty(title))
		{
			var movie = await _movieService.GetMovieAsync(title);
			return View("Index", movie);
		}
		return View("Index");
	}
}

