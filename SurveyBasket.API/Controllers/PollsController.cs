
using SurveyBasket.API.Services;

namespace SurveyBasket.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PollsController : ControllerBase
	{
		private readonly IPollservice _pollservice;

		public PollsController(IPollservice pollservice)
		{
			_pollservice = pollservice;
		}

		[HttpGet]
		public IActionResult  GetAll()
		{
		var polls=_pollservice.GetAll();
			return Ok(polls);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var poll = _pollservice.GetById(id);
			if (poll == null)
			{
				return NotFound();
			}
			return Ok(poll);


		}

		[HttpPost("")]
		public IActionResult Get(Poll poll)
		{
			var newpoll = _pollservice.Get(poll);

			return CreatedAtAction(nameof(Get), new { id = newpoll.id }, newpoll);

		}

		[HttpPut("{id}")]
		public IActionResult Updata(int id ,Poll Request )
		{
			var IsUpdated=_pollservice.Update(id, Request);
			if(!IsUpdated)
			return NotFound();
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var IsDeleted=_pollservice.Delete(id);
			if(!IsDeleted)
			{
				return NotFound();
			}
			return NoContent();
		}

	}
}
