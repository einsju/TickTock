using TickTock.Game;
using TickTock.Utilities;
using TMPro;
using UnityEngine;

namespace TickTock
{
    public class Timer : MonoBehaviour
    {
        public static float CurrentTime { get; private set; }

        [SerializeField] TextMeshProUGUI timerText;

        void Awake() => CurrentTime = 0f;

        void Update()
        {
            if (!GameManager.Instance.GameIsRunning) return;
            IncrementTimer();
        }

        void IncrementTimer()
        {
            CurrentTime += Time.deltaTime;
            timerText.text = CurrentTime.ToFormattedString();
        }
    }
}
