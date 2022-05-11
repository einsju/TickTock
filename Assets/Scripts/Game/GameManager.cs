using System.Threading.Tasks;
using TickTock.Utilities;
using UnityEngine;

namespace TickTock.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        // [SerializeField] LevelManager levelManager;
        // [SerializeField] ScoreManager scoreManager;
        // [SerializeField] GameAudioPlayer audioPlayer;
        // [SerializeField] Spawner spawner;
        
        public bool GameIsRunning { get; private set; }

        void Awake() => Instance = this;

        public void StartGame()
        {
            GameIsRunning = true;
            SceneLoader.UnloadScene(SceneNames.Menu);
            //GameStateEventHandler.OnGameStarted();
        }
        
        async Task GameOver()
        {
            // GameIsRunning = false;
            // audioPlayer.PlayGameOverSound();
            // PlayerDataInstance.Instance.UpdatePlayerAfterGameOver(scoreManager.Score);
            // await Task.Delay(1000);
            // GameStateEventHandler.OnGameOver();
            // await Task.Delay(500);
            // levelManager.PrepareLevel();
            // SceneLoader.LoadScene(SceneNames.Menu);
        }
    }
}
