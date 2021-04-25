using UnityEngine;
using UnityEngine.Events;

namespace Artistas
{
	public class NumberInsertionEventListener : MonoBehaviour
	{
		[SerializeField] private NumberInsertionEvent gameEvent;
		[SerializeField] private UnityEvent<string> response;

		private void OnEnable()
		{
			gameEvent.RegisterListener(this);
		}

		private void OnDisable()
		{
			gameEvent.UnregisterListener(this);
		}

		public void OnEventRaised(string numberString)
		{
			response.Invoke(numberString);
		}
	}
}
