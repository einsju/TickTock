namespace TickTock.Validators
{
    public interface IChallengeValidator
    {
        bool IsPlayerInputValid(float time);
        bool IsTimeLimitValid(float time);
    }
}