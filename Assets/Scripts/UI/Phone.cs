using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Artistas
{
    public class Phone : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI numberText;

        [Header("Call Events")]
        [SerializeField] private UnityEvent<Call> OnCallSent;
        [SerializeField] private UnityEvent<Call> OnCallReceived;
        [SerializeField] private UnityEvent<Call> OnCallAccepted;
        [SerializeField] private UnityEvent<Call> OnCallRefused;

        [Header("Phone Events")]
        [SerializeField] private UnityEvent<int> OnNumberPressed;

        public Call ReceivedCall { private get; set; }

        private bool onCall;

        public void SendCall(Call call)
        {
            if (onCall)
            {
                return;
            }

            OnCallSent.Invoke(call);
        }

        public void ReceiveCall(Call call)
        {
            if (onCall)
            {
                return;
            }

            ReceivedCall = call;

            OnCallReceived.Invoke(call);
        }

        public void AcceptCall()
        {
            if (ReceivedCall == null)
            {
                return;
            }

            OnCallAccepted.Invoke(ReceivedCall);

            onCall = true;

            ReceivedCall = null;
        }

        public void RefuseCall()
        {
            if (ReceivedCall == null)
            {
                return;
            }

            OnCallRefused.Invoke(ReceivedCall);

            onCall = false;

            ReceivedCall = null;
        }

        public void OnType(int number)
        {
            OnNumberPressed.Invoke(number);

            if (numberText.text.Length == 9)
            {
                return;
            }

            numberText.text += number.ToString();
        }

        public void OnRemove()
        {
            if (string.IsNullOrEmpty(numberText.text))
            {
                return;
            }

            numberText.text = numberText.text.Remove(numberText.text.Length - 1);
        }

        public void OnClear()
        {
            if (string.IsNullOrEmpty(numberText.text))
            {
                return;
            }

            numberText.text = "";
        }
    }
}