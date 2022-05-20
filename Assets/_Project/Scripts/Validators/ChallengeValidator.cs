using System;
using TickTock.Game;

namespace TickTock.Validators
{
    public class ChallengeValidator : IChallengeValidator
    {
        public static event Action ChallengeSucceeded;
        public static event Action ChallengeFailed;

        readonly Challenge _challenge;

        public ChallengeValidator(Challenge challenge) => _challenge = challenge;

        public bool IsPlayerInputValid(float timeWhenClicked)
        {
            var result = _challenge.operatorName switch
            {
                Operators.After => timeWhenClicked >= _challenge.timeToExecute.Start,
                Operators.Before => timeWhenClicked <= _challenge.timeToExecute.Start,
                Operators.Between => timeWhenClicked >= _challenge.timeToExecute.Start &&
                                     timeWhenClicked <= _challenge.timeToExecute.Stop,
                Operators.Equal => Math.Abs(timeWhenClicked - _challenge.timeToExecute.Start) < float.Epsilon,
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

        public bool IsTimeLimitValid(float time)
        {
            var result = _challenge.operatorName switch
            {
                Operators.Before => time < _challenge.timeToExecute.Start,
                Operators.Between => time < _challenge.timeToExecute.Stop,
                Operators.Equal => time < _challenge.timeToExecute.Start,
                _ => true
            };
            
            if (!result)
                ChallengeFailed?.Invoke();

            return result;
        }
    }
}
