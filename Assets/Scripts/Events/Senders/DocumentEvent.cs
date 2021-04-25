using System.Collections.Generic;
using UnityEngine;

namespace Artistas
{
    [CreateAssetMenu(fileName = "NewCallEvent", menuName = "Artistas/Events/New Document Event")]
    public class DocumentEvent : ScriptableObject
    {
        private readonly List<DocumentEventListener> eventListeners = new List<DocumentEventListener>();

        public void Raise(DocumentSO document)
        {
            for (int i = eventListeners.Count - 1; i >= 0; --i)
            {
                eventListeners[i].OnEventRaised(document);
            }
        }

        public void RegisterListener(DocumentEventListener listener)
        {
            if (eventListeners.Contains(listener))
            {
                return;
            }

            eventListeners.Add(listener);
        }

        public void UnregisterListener(DocumentEventListener listener)
        {
            if (!eventListeners.Contains(listener))
            {
                return;
            }

            eventListeners.Remove(listener);
        }
    }
}