using System;
using TMPro;
using UnityEngine;

namespace TickTock
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI tick;
        [SerializeField] TextMeshProUGUI gameStatusText;
        
        float _timer;
        bool _isPlaying;

        void Start() => _isPlaying = true;

        void Update()
        {
            if (!_isPlaying) return;
            _timer += Time.deltaTime;
            tick.text = TimeSpan.FromSeconds(_timer).ToString(@"mm\:ss\:ff");
        }

        public void HitButton()
        {
            if (_timer >= 2f && _timer <= 2.4f)
            {
                gameStatusText.text = "Congratulations. You won!!!";
                _isPlaying = false;
            }
            else
            {
                gameStatusText.text = "You lost!!!";
                _timer = 0;
            }
        }
    }
}
