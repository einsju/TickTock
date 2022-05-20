using System;
using TickTock.Utilities;
using TickTock.Validators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TickTock.Game
{
    public class ChallengeButton : MonoBehaviour
    {
        public static event Action ChallengeButtonClicked;
        
        public bool IsAnswered { get; private set; }
        
        [SerializeField] Challenge challenge;
        [SerializeField] TextMeshProUGUI operatorText;
        [SerializeField] TextMeshProUGUI challengeText;
        
        Button _button;
        ChallengeValidator _challengeValidator;

        void Awake()
        {
            _challengeValidator = new ChallengeValidator(challenge);
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnChallengeAnswered);
            operatorText.text = challenge.OperatorNameLabel;
            challengeText.text = challenge.timeToExecute.ToString();
        }

        void Update()
        {
            if (IsAnswered) return;
            var isValid = _challengeValidator.IsTimeLimitValid(Timer.CurrentTime);
            if (isValid) return;
            IsAnswered = true;
            _button.interactable = false;
            GetComponent<Image>().color = Color.red;
        }

        void OnDestroy() => _button.onClick.RemoveListener(OnChallengeAnswered);

        void OnChallengeAnswered()
        {
            var timeWhenClicked = Timer.CurrentTime;
            
            IsAnswered = true;
            _button.interactable = false;
            SetChallengeText(timeWhenClicked.ToFormattedString());
            ValidateAnswer(timeWhenClicked);
            ChallengeButtonClicked?.Invoke();
        }

        void SetChallengeText(string text) => challengeText.text = text;

        void ValidateAnswer(float time)
        {
            var isValid = _challengeValidator.IsPlayerInputValid(time);
            var imageColor = isValid ? Color.green : Color.red;
            GetComponent<Image>().color = imageColor;
        }
    }
}
