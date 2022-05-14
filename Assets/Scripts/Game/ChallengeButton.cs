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
        
        Button _button;
        TextMeshProUGUI _challengeText;

        void Awake()
        {
            _button = GetComponent<Button>();
            _challengeText = GetComponentInChildren<TextMeshProUGUI>();
            _button.onClick.AddListener(OnChallengeExecuted);
        }

        void OnDestroy() => _button.onClick.RemoveListener(OnChallengeExecuted);

        void Start() => SetChallengeText(challenge.OperatorNameLabel);

        void OnChallengeExecuted()
        {
            var timeWhenClicked = Timer.CurrentTime;

            IsAnswered = true;
            _button.interactable = false;
            SetChallengeText(timeWhenClicked.ToFormattedString());
            ValidateAnswer(timeWhenClicked);
            ChallengeButtonClicked?.Invoke(challenge, timeWhenClicked);
        }

        void SetChallengeText(string text) => _challengeText.text = text;

        void ValidateAnswer(float time)
        {
            var imageColor = challenge.IsExecutedSuccessfully(time) ? Color.green : Color.red;
            GetComponent<Image>().color = imageColor;
        }
    }
}
