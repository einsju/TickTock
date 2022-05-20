using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TickTock.Game
{
    public class ChallengeManager : MonoBehaviour
    {   
        List<ChallengeButton> _challengeButtons;
        
        bool LevelIsFinished => _challengeButtons.All(b => b.IsAnswered);

        void Awake()
        {
            _challengeButtons = GetComponentsInChildren<ChallengeButton>().ToList();
            ChallengeButton.ChallengeButtonClicked += ChallengeAnswered;
        }

        void OnDestroy() => ChallengeButton.ChallengeButtonClicked -= ChallengeAnswered;

        void ChallengeAnswered()
        {
            if (!LevelIsFinished) return;
            GameManager.Instance.StopGame();
        }
    }
}
