using System.Collections.Generic;
using UnityEngine;

namespace Artistas
{
    [CreateAssetMenu(fileName = "NewDialogueEvent", menuName = "Artistas/Events/New Dialogue Event")]
    public class DialogueEvent : ScriptableObject
    {
        private readonly List<DialogueEventListener> eventListeners = new List<DialogueEventListener>();

        public void Raise(DialogueSO dialogue)
        {
            for (int i = eventListeners.Count - 1; i >= 0; --i)
            {
                eventListeners[i].OnEventRaised(dialogue);
            }
        }

        public void RegisterListener(DialogueEventListener listener)
        {
            if (eventListeners.Contains(listener))
            {
                return;
            }

            eventListeners.Add(listener);
        }

        public void UnregisterListener(DialogueEventListener listener)
        {
            if (!eventListeners.Contains(listener))
            {
                return;
            }

            eventListeners.Remove(listener);
        }
    }
}