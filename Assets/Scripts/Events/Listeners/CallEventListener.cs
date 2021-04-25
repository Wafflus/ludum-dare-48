using UnityEngine;
using UnityEngine.Events;

namespace Artistas
{
    public class CallEventListener : MonoBehaviour
    {
        [SerializeField] private CallEvent gameEvent;
        [SerializeField] private UnityEvent<Call> response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(Call call)
        {
            response.Invoke(call);
        }
    }
}