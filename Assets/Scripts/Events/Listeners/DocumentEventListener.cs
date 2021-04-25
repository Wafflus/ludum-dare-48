using UnityEngine;
using UnityEngine.Events;

namespace Artistas
{
    public class DocumentEventListener : MonoBehaviour
    {
        [SerializeField] private DocumentEvent gameEvent;
        [SerializeField] private UnityEvent<DocumentSO> response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(DocumentSO document)
        {
            response.Invoke(document);
        }
    }
}