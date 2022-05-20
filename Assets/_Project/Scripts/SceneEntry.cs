using UnityEngine;
using UnityEngine.EventSystems;

namespace TickTock
{
    public class SceneEntry : MonoBehaviour
    {
        void Awake()
        {
            // Deactivate if multiples of objects that should only exist once in the game
            if (!ShouldShutDown()) return;
            Destroy(gameObject);
        }

        static bool ShouldShutDown() =>
            FindObjectsOfType<EventSystem>().Length > 1;
    }
}
