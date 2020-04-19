using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Camera))]
    public class GameplayCameraController : MonoBehaviour
    {
        private void Awake()
        {
            Contexts.sharedInstance.gameflow.ReplaceGameplayCamera(GetComponent<Camera>());
        }
    }
}