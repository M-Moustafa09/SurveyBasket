
namespace SurveyBasket.API.Services
{
	public class PollService : IPollservice
	{
		private static readonly List<Poll> polls =
			[
			new Poll
				{id = 1, name = "Poll 1", description = "Description for Poll 1" },
			new Poll
			{id = 2, name = "Poll 2", description = "Description for Poll 2" },
			new Poll
			{id = 3, name = "Poll 3", description = "Description for Poll 3" },
			];


		public IEnumerable<Poll> GetAll() => polls;
		
		public Poll? GetById(int id)=> polls.FirstOrDefault(p => p.id == id);
		public Poll Get(Poll poll)
		{
			poll.id = polls.Count()+1;
			polls.Add(poll);
			return poll;
		}

		public bool Update(int id, Poll poll)
		{
			var currentpoll = GetById(id);
			if(currentpoll is null)
			{
				return false;
			}
			currentpoll.name=poll.name;
			currentpoll.description=poll.description;
			return true;
		}

		public bool Delete(int id)
		{
			var currentPoll = GetById(id);
			if(currentPoll is null)
			{
				return false;
			}
			polls.Remove(currentPoll);
			return true;
		}
	}
}
