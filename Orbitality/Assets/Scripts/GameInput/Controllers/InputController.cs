using UnityEngine;

namespace GameInput.Controllers
{
    public class InputController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Contexts.sharedInstance.gameInput.CreateEntity().isMouseClick = true;
            }

            var position = Input.mousePosition;
            Contexts.sharedInstance.gameInput.ReplaceMousePosition(position);
            
            var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
            if (scrollWheel != 0)
            {
                Contexts.sharedInstance.gameInput
                    .CreateEntity()
                    .ReplaceMouseScrollWheel(scrollWheel);
            }
        }
    }
}