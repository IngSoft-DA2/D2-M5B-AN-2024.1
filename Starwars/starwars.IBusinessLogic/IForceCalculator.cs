using System;
using starwars.Domain;

namespace starwars.IBusinessLogic
{
	public interface IForceCalculator
	{
        public Character DetermineCharacter(IEnumerable<QuestionAnswer> answers);
        public List<Question> GetQuestions();
    }
}

