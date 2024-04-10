using System;
using starwars.Domain;
using starwars.IBusinessLogic;

namespace starwars.BusinessLogic
{
    public class ForceCalculator : IForceCalculator
    {
        private readonly IForceCalcStrategy _jediStrategy;
        private readonly IForceCalcStrategy _sithStrategy;
        private readonly IPersonalityQuestion _questionProvider;

        public ForceCalculator(IForceCalcStrategy jediStrategy, IForceCalcStrategy sithStrategy, IPersonalityQuestion questionProvider)
        {
            _jediStrategy = jediStrategy;
            _sithStrategy = sithStrategy;
            _questionProvider = questionProvider;
        }

        public Character DetermineCharacter(IEnumerable<QuestionAnswer> answers)
        {
            int jediForce = _jediStrategy.CalculateForce(answers);
            int sithForce = _sithStrategy.CalculateForce(answers);

            if (jediForce > sithForce)
                return _jediStrategy.DetermineCharacter(jediForce);
            else
                return _sithStrategy.DetermineCharacter(sithForce);
           }

        public List<Question> GetQuestions()
        {
            return _questionProvider.GetQuestions();
        }
    }

}

