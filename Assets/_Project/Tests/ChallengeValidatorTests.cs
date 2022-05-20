using NUnit.Framework;
using TickTock.Game;
using TickTock.Utilities;
using TickTock.Validators;

namespace TickTock
{
    public class ChallengeValidatorTests
    {
        IChallengeValidator _challengeValidator;

        static Challenge ChallengeToTest(Operators operatorName) =>
            new() { operatorName = operatorName, timeToExecute = new TimeInterval(3f, 5f) };

        [TestCase(Operators.After, 2.9f)]
        [TestCase(Operators.Before, 3.1f)]
        [TestCase(Operators.Between, 10f)]
        [TestCase(Operators.Equal, 2.99f)]
        public void IsPlayerInputValid_ShouldReturnFalse_WhenInputIsNotValid(Operators operatorName, float timeWhenClicked)
        {
            var challenge = ChallengeToTest(operatorName);

            _challengeValidator = new ChallengeValidator(challenge);

            var result = _challengeValidator.IsPlayerInputValid(timeWhenClicked);

            Assert.IsFalse(result);
        }

        [TestCase(Operators.After, 3.1f)]
        [TestCase(Operators.Before, 2f)]
        [TestCase(Operators.Between, 4f)]
        [TestCase(Operators.Equal, 3f)]
        public void IsPlayerInputValid_ShouldReturnTrue_WhenInputIsValid(Operators operatorName, float timeWhenClicked)
        {
            var challenge = ChallengeToTest(operatorName);

            _challengeValidator = new ChallengeValidator(challenge);

            var result = _challengeValidator.IsPlayerInputValid(timeWhenClicked);

            Assert.IsTrue(result);
        }
        
        [Test]
        public void IsPlayerInputValid_ShouldRaiseFailedEvent_WhenInputIsNotValid()
        {
            var challenge = ChallengeToTest(Operators.After);
            var raised = false;

            _challengeValidator = new ChallengeValidator(challenge);
            
            ChallengeValidator.ChallengeFailed += () => raised = true;
            
            _challengeValidator.IsPlayerInputValid(2f);

            Assert.IsTrue(raised);
        }
        
        [Test]
        public void IsPlayerInputValid_ShouldRaiseSucceededEvent_WhenInputIsValid()
        {
            var challenge = ChallengeToTest(Operators.After);
            var raised = false;

            _challengeValidator = new ChallengeValidator(challenge);
            
            ChallengeValidator.ChallengeSucceeded += () => raised = true;
            
            _challengeValidator.IsPlayerInputValid(4f);

            Assert.IsTrue(raised);
        }
        
        [TestCase(Operators.Before, 3.2f)]
        [TestCase(Operators.Between, 10f)]
        [TestCase(Operators.Equal, 3.79f)]
        public void IsTimeLimitValid_ShouldReturnFalse_WhenViolated(Operators operatorName, float time)
        {
            var challenge = ChallengeToTest(operatorName);

            _challengeValidator = new ChallengeValidator(challenge);

            var result = _challengeValidator.IsTimeLimitValid(time);

            Assert.IsFalse(result);
        }
        
        [TestCase(Operators.Before, 2.2f)]
        [TestCase(Operators.Between, 4.32f)]
        [TestCase(Operators.Equal, 2f)]
        public void IsTimeLimitValid_ShouldReturnTrue_WhenNotViolated(Operators operatorName, float time)
        {
            var challenge = ChallengeToTest(operatorName);

            _challengeValidator = new ChallengeValidator(challenge);

            var result = _challengeValidator.IsTimeLimitValid(time);

            Assert.IsTrue(result);
        }
        
        [Test]
        public void IsTimeLimitValid_ShouldRaiseFailedEvent_WhenViolated()
        {
            var challenge = ChallengeToTest(Operators.Before);
            var raised = false;

            _challengeValidator = new ChallengeValidator(challenge);
            
            ChallengeValidator.ChallengeFailed += () => raised = true;
            
            _challengeValidator.IsTimeLimitValid(3.23f);

            Assert.IsTrue(raised);
        }
    }
}
