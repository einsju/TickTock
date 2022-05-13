using TMPro;
using UnityEngine;

namespace TickTock.Game
{
    public class ChallengeButton : MonoBehaviour
    {
        [SerializeField] Challenge challenge;
        
        TextMeshProUGUI _challengeText;

        void Awake() => _challengeText = GetComponentInChildren<TextMeshProUGUI>();

        void Start()
        {
            _challengeText.text = challenge.OperatorNameLabel;
        }
    }
}
