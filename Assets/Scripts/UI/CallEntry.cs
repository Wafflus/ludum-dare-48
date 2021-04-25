using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Artistas
{
    public class CallEntry : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI number;
        [SerializeField] private TextMeshProUGUI contactName;
        [SerializeField] private Button button;

        [Header("Events")]
        [SerializeField] private CallEvent callEvent;

        private Call currentCall;

        public void Initialize(Call call)
        {
            currentCall = call;

            number.text = call.callerNumber;
            contactName.text = call.callerName;

            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            callEvent.Raise(currentCall);
        }
    }
}