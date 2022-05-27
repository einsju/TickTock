using NUnit.Framework;
using TickTock.Generators;

namespace TickTock
{
    public class ChallengeGeneratorTests
    {
        readonly IChallengeGenerator _challengeGenerator = new ChallengeGenerator();

        [Test]
        public void GetRandomChallengeBasedOnTime_ShouldReturnValidChallenge_BasedOnTime()
        {
            var currentTime = 2f;

            var challenge = _challengeGenerator.GetRandomChallengeBasedOnTime(currentTime);
            
            Assert.IsTrue(challenge.timeToExecute.Start > currentTime);
        }
    }
}
