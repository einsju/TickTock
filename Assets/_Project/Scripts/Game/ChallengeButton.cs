using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TickTock.Game
{
    public class ChallengeButton : MonoBehaviour
    {
        public static event Action<float> ChallengeButtonClicked;
        
        [SerializeField] TextMeshProUGUI operatorText;
        [SerializeField] TextMeshProUGUI challengeText;
        
        Button _button;
        Challenge _challenge;

        void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnChallengeButtonClicked);
        }

        void OnDestroy() => _button.onClick.RemoveListener(OnChallengeButtonClicked);
        
        static void OnChallengeButtonClicked() => ChallengeButtonClicked?.Invoke(Timer.CurrentTime);

        public void SetChallenge(Challenge challenge)
        {
            _challenge = challenge;
            operatorText.text = _challenge.OperatorNameLabel;
            challengeText.text = _challenge.timeToExecute.ToString();
        }

        public void ChallengeSucceeded()
        {
            GetComponent<Image>().color = Color.green;
        }

        public void ChallengeFailed()
        {
            GetComponent<Image>().color = Color.red;
        }
    }
}
