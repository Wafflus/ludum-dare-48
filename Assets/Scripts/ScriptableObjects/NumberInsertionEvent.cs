using UnityEngine;
using System.Collections.Generic;

namespace Artistas
{
	[CreateAssetMenu(fileName = "NewNumberInsertionEvent", menuName = "Artistas/Events/New Number Insertion Event")]
	public class NumberInsertionEvent : ScriptableObject
	{
		private readonly List<NumberInsertionEventListener> eventListeners = new List<NumberInsertionEventListener>();

		public void Raise(string numberString)
		{
			for (int i = eventListeners.Count - 1; i >= 0; --i)
			{
				eventListeners[i].OnEventRaised(numberString);
			}
		}

		public void RegisterListener(NumberInsertionEventListener listener)
		{
			if (eventListeners.Contains(listener))
			{
				return;
			}

			eventListeners.Add(listener);
		}

		public void UnregisterListener(NumberInsertionEventListener listener)
		{
			if (!eventListeners.Contains(listener))
			{
				return;
			}

			eventListeners.Remove(listener);
		}
	}
}