using System.Threading.Tasks;
using TickTock.Utilities;
using UnityEngine;

namespace TickTock.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        // [SerializeField] LevelManager levelManager;
        // [SerializeField] ScoreManager scoreManager;
        // [SerializeField] GameAudioPlayer audioPlayer;
        // [SerializeField] Spawner spawner;
        
        public bool GameIsRunning { get; private set; }
        public int Level { get; private set; }

        void Awake() => Instance = this;

        public void StartGame()
        {
            Level = 1;
            GameIsRunning = true;
            SceneLoader.UnloadScene(SceneNames.Menu);
            SceneLoader.LoadScene($"{SceneNames.Level}{Level}");
            //GameStateEventHandler.OnGameStarted();
        }

        public void StopGame()
        {
            GameIsRunning = false;
        }
        
        async Task GameOver()
        {
            // GameIsRunning = false;
            // audioPlayer.PlayGameOverSound();
            // PlayerDataInstance.Instance.UpdatePlayerAfterGameOver(scoreManager.Score);
            await Task.Delay(1000);
            // GameStateEventHandler.OnGameOver();
            // await Task.Delay(500);
            // levelManager.PrepareLevel();
            // SceneLoader.LoadScene(SceneNames.Menu);
        }
    }
}
