using TickTock.Game;
using TickTock.Utilities;
using TMPro;
using UnityEngine;

namespace TickTock
{
    public class Timer : MonoBehaviour
    {
        public static float CurrentTime { get; private set; }
        
        TextMeshProUGUI _timerText;

        void Awake()
        {
            _timerText = GetComponent<TextMeshProUGUI>();
            CurrentTime = 0f;
            if (GameManager.Instance.Level > 1)
                CurrentTime = 60 * (GameManager.Instance.Level - 1);
        }

        void Update()
        {
            if (!GameManager.Instance.GameIsRunning) return;
            IncrementTimer();
        }

        void IncrementTimer()
        {
            CurrentTime += Time.deltaTime;
            _timerText.text = CurrentTime.ToFormattedString();
        }
    }
}
