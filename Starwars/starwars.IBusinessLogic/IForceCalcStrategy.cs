using starwars.Domain;

namespace starwars.IBusinessLogic;
public interface IForceCalcStrategy
{
    int CalculateForce(IEnumerable<QuestionAnswer> answers);
    Character DetermineCharacter(int forceLevel);
}


