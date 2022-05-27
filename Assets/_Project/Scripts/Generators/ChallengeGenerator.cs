using TickTock.Game;
using TickTock.Utilities;

namespace TickTock.Generators
{
    public class ChallengeGenerator : IChallengeGenerator
    {
        public Challenge GetRandomChallengeBasedOnTime(float time)
        {
            return new Challenge
            {
                operatorName = Operators.Before,
                timeToExecute = new TimeInterval(3f, 0f)
            };
        }
    }
}