using TickTock.Generators;
using TickTock.Validators;
using UnityEngine;

namespace TickTock.Game
{
    public class ChallengeManager : MonoBehaviour
    {
        Challenge _currentChallenge;
        ChallengeButton _challengeButton;
        IChallengeGenerator _challengeGenerator;
        IChallengeValidator _challengeValidator;

        void Awake()
        {
            _challengeValidator = new ChallengeValidator();
            _challengeGenerator = new ChallengeGenerator();
            _challengeButton = GetComponentInChildren<ChallengeButton>();
            ChallengeButton.ChallengeButtonClicked += OnChallengeButtonClicked;
        }
        
        void OnDestroy() => ChallengeButton.ChallengeButtonClicked -= OnChallengeButtonClicked;

        void Start() => GenerateChallenge();

        void GenerateChallenge()
        {
            _currentChallenge = _challengeGenerator.GetRandomChallengeBasedOnTime(Timer.CurrentTime);
            _challengeButton.SetChallenge(_currentChallenge);
        }

        void Update()
        {
            if (_challengeValidator.IsTimeLimitValid(_currentChallenge, Timer.CurrentTime)) return;
            _challengeButton.ChallengeFailed();
            
            // If more lives then generate a new fucking challenge...
            GameManager.Instance.StopGame();
        }

        void OnChallengeButtonClicked(float time)
        {
            if (_challengeValidator.IsPlayerInputValid(_currentChallenge, time))
            {
                _challengeButton.ChallengeSucceeded();
                return;
            }
            
            _challengeButton.ChallengeFailed();
            //GameManager.Instance.StopGame();
            
            // If  more lives then generate a new fucking challenge...
        }
    }
}
