using Microsoft.AspNetCore.Mvc;
using QuizMaster3000.Models;
using QuizMaster3000.Providers;

namespace QuizMaster3000.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class QuizController : ControllerBase
	{
		private readonly QuizProvider provider;

		public QuizController(QuizProvider quizProvider)
		{
			provider = quizProvider;
		}

		[HttpGet]
		[Route("")]
		public IActionResult GetQuizzes()
		{
			return Ok(provider.GetQuizzes());
		}

		[HttpGet]
		[Route("random/{amount}")]
		public async Task<IActionResult> GetRandomQuizzes([FromRoute] int amount)
		{
			Random random = new Random();
			await Task.Delay(random.Next(500, 5000));
			return Ok(await provider.GenerateQuizzesAsync(amount));
		}

		[HttpGet]
		[Route("data")]
		public async Task<IActionResult> GetQuizDataAsync()
		{
			return Ok(await provider.GetQuizDataAsync());
		}

		[HttpPost]
		[Route("")]
		public async Task<IActionResult> PostQuiz() //momentalne jen testovaci data, pozdeji asi bude nejake ui
		{
			return Ok(await provider.PostQuizAsync(10, 2, RoomState.InLobby,new List<Player>()));//prazdni players
		}
	}
}