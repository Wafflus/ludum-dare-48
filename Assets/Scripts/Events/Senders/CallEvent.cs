using System.Collections.Generic;
using UnityEngine;

namespace Artistas
{
    [CreateAssetMenu(fileName = "NewCallEvent", menuName = "Artistas/Events/New Call Event")]
    public class CallEvent : ScriptableObject
    {
        private readonly List<CallEventListener> eventListeners = new List<CallEventListener>();

        public void Raise(Call call)
        {
            for (int i = eventListeners.Count - 1; i >= 0; --i)
            {
                eventListeners[i].OnEventRaised(call);
            }
        }

        public void RegisterListener(CallEventListener listener)
        {
            if (eventListeners.Contains(listener))
            {
                return;
            }

            eventListeners.Add(listener);
        }

        public void UnregisterListener(CallEventListener listener)
        {
            if (!eventListeners.Contains(listener))
            {
                return;
            }

            eventListeners.Remove(listener);
        }
    }
}