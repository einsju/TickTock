using TickTock.Utilities;
using UnityEngine;

namespace TickTock
{
    public class ApplicationEntry : MonoBehaviour
    {
        void Start()
        {
            // Always start game with options activated 
            SceneLoader.LoadScene(SceneNames.Menu);
        }
    }
}
