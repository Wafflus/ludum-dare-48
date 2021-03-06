using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Artistas
{
    public class Phone : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI numberText;

        [Header("Call")]
        [SerializeField] private Call firstCall;
        [SerializeField] private CallSwitcherSO callSwitcher;

        [Header("Call Events")]
        [SerializeField] private UnityEvent<Call> OnCallSent;
        [SerializeField] private UnityEvent<Call> OnCallReceived;
        [SerializeField] private UnityEvent<Call> OnCallAccepted;
        [SerializeField] private UnityEvent<Call> OnCallRefused;

        [Header("Phone Events")]
        [SerializeField] private UnityEvent<int> OnNumberPressed;

        public Call ReceivedCall { private get; set; }

        private bool onCall;

        private void Start()
        {
            ReceiveCall(firstCall);
        }

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
        }

        public void RefuseCall()
        {
            if (ReceivedCall == null)
            {
                return;
            }

            if (!onCall)
            {
                return;
            }

            OnCallRefused.Invoke(ReceivedCall);

            onCall = false;

            ReceivedCall = null;
        }

        public void Interact()
        {
            if (ReceivedCall == null)
            {
                if (numberText.text.Length == 9)
                {
                    Call call = callSwitcher.GetCall(numberText.text);

                    if (call == null)
                    {
                        return;
                    }

                    SendCall(call);
                }

                return;
            }

            if (onCall)
            {
                RefuseCall();

                return;
            }

            AcceptCall();
        }

        public void SetNumber(string numberString)
        {
            if (onCall)
            {
                return;
            }

            numberText.text = numberString;
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