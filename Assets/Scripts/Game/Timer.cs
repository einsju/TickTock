using System;
using TickTock.Game;
using TMPro;
using UnityEngine;

namespace TickTock
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timerText;
        
        float _timer;

        public float CurrentTime => _timer;

        void Update()
        {
            if (!GameManager.Instance.GameIsRunning) return;
            IncrementTimer();
        }

        void IncrementTimer()
        {
            _timer += Time.deltaTime;
            timerText.text = TimeSpan.FromSeconds(_timer).ToString(@"mm\:ss\:ff");
        }
    }
}
