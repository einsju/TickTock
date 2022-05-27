using TickTock.Game;

namespace TickTock.Generators
{
    public interface IChallengeGenerator
    {
        Challenge GetRandomChallengeBasedOnTime(float time);
    }
}