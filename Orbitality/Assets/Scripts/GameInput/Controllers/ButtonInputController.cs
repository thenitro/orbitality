using UnityEngine;
using UnityEngine.UI;

namespace GameInput.Controllers
{
    [RequireComponent(typeof(Button))]
    public class ButtonInputController : MonoBehaviour
    {
        [SerializeField] public InputButtons _buttonName;
        
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
            _button = null;
        }

        private void OnClick()
        {
            Contexts.sharedInstance.gameInput.CreateEntity().ReplaceButtonClick(_buttonName);
        }
    }
}