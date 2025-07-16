namespace SurveyBasket.API.Services
{
	public interface IPollservice
	{
		IEnumerable<Poll> GetAll();
		Poll? GetById(int id);
		Poll Get(Poll poll);
		bool Update(int id ,Poll poll);
		bool Delete(int id);
	}
}
