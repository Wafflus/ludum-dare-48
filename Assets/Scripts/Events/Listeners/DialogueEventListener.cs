using UnityEngine;
using UnityEngine.Events;

namespace Artistas
{
    public class DialogueEventListener : MonoBehaviour
    {
        [SerializeField] private DialogueEvent gameEvent;
        [SerializeField] private UnityEvent<DialogueSO> response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(DialogueSO dialogue)
        {
            response.Invoke(dialogue);
        }
    }
}