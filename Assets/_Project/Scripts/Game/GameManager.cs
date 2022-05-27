using System.Threading.Tasks;
using TickTock.Utilities;
using TickTock.Validators;
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
        [SerializeField] Player player;
        
        public bool GameIsRunning { get; private set; }

        void Awake()
        {
            Instance = this;
            ChallengeValidator.ChallengeSucceeded += OnChallengeSucceeded;
            ChallengeValidator.ChallengeFailed += OnChallengeFailed;
        }

        void OnDestroy()
        {
            ChallengeValidator.ChallengeSucceeded -= OnChallengeSucceeded;
            ChallengeValidator.ChallengeFailed -= OnChallengeFailed;
        }
        
        void OnChallengeSucceeded()
        {
            if (!GameIsRunning) return;
            player.AddLife();
        }

        void OnChallengeFailed()
        {
            if (!GameIsRunning) return;
            player.TakeLife();
            if (player.Lives == 0) StopGame();
        }

        public void StartGame()
        {
            GameIsRunning = true;
            SceneLoader.UnloadScene(SceneNames.Menu);
            SceneLoader.LoadScene($"{SceneNames.Game}");
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
