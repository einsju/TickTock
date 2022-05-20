using TMPro;
using UnityEngine;

namespace TickTock
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public int Lives { get; private set; } = 3;
        [SerializeField] TextMeshProUGUI livesText;

        void Awake() => DisplayLives();

        public void AddLife(int livesToAdd = 1)
        {
            Lives += livesToAdd;
            DisplayLives();
        }

        public void TakeLife()
        {
            Lives--;
            DisplayLives();
        }

        void DisplayLives() => livesText.text = $"{Lives}";
    }
}
