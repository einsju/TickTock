using System;
using TickTock.Game;

namespace TickTock.Validators
{
    public class ChallengeValidator : IChallengeValidator
    {
        public static event Action ChallengeSucceeded;
        public static event Action ChallengeFailed;

        public bool IsPlayerInputValid(Challenge challenge, float timeWhenClicked)
        {
            var result = challenge.operatorName switch
            {
                Operators.Before => timeWhenClicked <= challenge.timeToExecute.Start,
                Operators.Between => timeWhenClicked >= challenge.timeToExecute.Start &&
                                     timeWhenClicked <= challenge.timeToExecute.Stop,
                Operators.Equal => Math.Abs(timeWhenClicked - challenge.timeToExecute.Start) < float.Epsilon,
                _ => false
            };

            if (!result)
            {
                ChallengeFailed?.Invoke();
                return false;
            }

            ChallengeSucceeded?.Invoke();
            return true;
        }

        public bool IsTimeLimitValid(Challenge challenge, float time)
        {
            var result = challenge.operatorName switch
            {
                Operators.Before => time < challenge.timeToExecute.Start,
                Operators.Between => time < challenge.timeToExecute.Stop,
                Operators.Equal => time < challenge.timeToExecute.Start,
                _ => true
            };
            
            if (!result)
                ChallengeFailed?.Invoke();

            return result;
        }
    }
}
