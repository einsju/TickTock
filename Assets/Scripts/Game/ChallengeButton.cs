using System;
using TickTock.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TickTock.Game
{
    public class ChallengeButton : MonoBehaviour
    {
        public static event Action<Challenge, float> ChallengeButtonClicked;
        
        public bool IsAnswered { get; private set; }
        
        [SerializeField] Challenge challenge;
        [SerializeField] TextMeshProUGUI operatorText;
        [SerializeField] TextMeshProUGUI challengeText;
        
        Button _button;

        void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnChallengeExecuted);
            operatorText.text = challenge.OperatorNameLabel;
            challengeText.text = challenge.timeToExecute.ToString();
        }

        void OnDestroy() => _button.onClick.RemoveListener(OnChallengeExecuted);

        void OnChallengeExecuted()
        {
            var timeWhenClicked = Timer.CurrentTime;

            IsAnswered = true;
            _button.interactable = false;
            SetChallengeText(timeWhenClicked.ToFormattedString());
            ValidateAnswer(timeWhenClicked);
            ChallengeButtonClicked?.Invoke(challenge, timeWhenClicked);
        }

        void SetChallengeText(string text) => challengeText.text = text;

        void ValidateAnswer(float time)
        {
            var imageColor = challenge.IsExecutedSuccessfully(time) ? Color.green : Color.red;
            GetComponent<Image>().color = imageColor;
        }
    }
}
