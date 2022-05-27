using TickTock.Game;

namespace TickTock.Validators
{
    public interface IChallengeValidator
    {
        bool IsPlayerInputValid(Challenge challenge, float time);
        bool IsTimeLimitValid(Challenge challenge, float time);
    }
}