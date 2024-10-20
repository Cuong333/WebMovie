using Microsoft.AspNetCore.Mvc;

public class MovieController : Controller
{
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

