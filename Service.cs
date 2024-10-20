using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebMovie.Models;

public class MovieService
{
	private readonly HttpClient _httpClient;
	private readonly string _apiKey;

	public MovieService(HttpClient httpClient, IConfiguration configuration)
	{
		_httpClient = httpClient;
		_apiKey = configuration["OMDb:ApiKey"]; // Lấy API key từ file cấu hình.
	}

	public async Task<Movie> GetMovieAsync(string title)
	{
		try
		{
			var builder = new UriBuilder("http://www.omdbapi.com/");
			var query = $"apikey={_apiKey}&t={Uri.EscapeDataString(title)}";
			builder.Query = query;

			var response = await _httpClient.GetAsync(builder.Uri);

			if (response.IsSuccessStatusCode)
			{
				var jsonResult = await response.Content.ReadAsStringAsync();
				var movie = JsonConvert.DeserializeObject<Movie>(jsonResult);

				return movie;
			}
			else
			{
				// Log lỗi và trả về null hoặc thông báo lỗi tùy ý
				Console.WriteLine($"Error: {response.ReasonPhrase}");
				return null;
			}
		}
		catch (HttpRequestException ex)
		{
			// Xử lý các lỗi mạng, API không phản hồi, v.v.
			Console.WriteLine($"Request error: {ex.Message}");
			return null;
		}
		catch (Exception ex)
		{
			// Xử lý các lỗi khác
			Console.WriteLine($"General error: {ex.Message}");
			return null;
		}
	}
}
