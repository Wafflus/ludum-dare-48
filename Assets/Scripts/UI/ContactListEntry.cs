using UnityEngine;
using UnityEngine.UI;

namespace Artistas
{
	public class ContactListEntry : MonoBehaviour
	{
		[Header("UI Elements")]
		[SerializeField] private Text numberText;
		[SerializeField] private Text identifierText;

		[Header("Phone Events")]
		[SerializeField] private NumberInsertionEvent OnEntryClick;

		private string number;

		public void LoadInformation(string number, string identifier)
		{
			this.number = number;
			numberText.text = FormattedNumber(number);
			identifierText.text = identifier;
		}

		public void RaiseEntryClickEvent()
		{
			OnEntryClick.Raise(number);
		}

		private string FormattedNumber(string number)
		{
			return number.Substring(0, 3) + " " + number.Substring(3, 3) + " " + number.Substring(6);
		}
	}
}