using System;
using System.Collections.Generic;
using UnityEngine;

namespace Artistas
{
	public class ContactList : MonoBehaviour
	{
		[Header("Contacts")]
		[SerializeField] private NPC[] npcContacts;

		[Header("UI Elements")]
		[SerializeField] private GameObject contactListUIParent;
		[SerializeField] private GameObject emptyContactListEntryPrefab;

		public void UpdateContactListUI()
		{
			ClearOldUIEntries();

			List<Tuple<string, string>> discoveredContactTuples = GetOrderedDiscoveredContacts();

			for (int i = 0; i < discoveredContactTuples.Count; ++i)
			{
				GameObject newEntryUIElement = Instantiate(emptyContactListEntryPrefab, contactListUIParent.transform);

				newEntryUIElement.GetComponent<ContactListEntry>().LoadInformation(discoveredContactTuples[i].Item2, discoveredContactTuples[i].Item1);
			}
		}

		// I don't know if there's a better way to do this.
		private void ClearOldUIEntries()
		{
			foreach (Transform child in contactListUIParent.transform)
			{
				Destroy(child.gameObject);
			}
		}

		private List<Tuple<string, string>> GetOrderedDiscoveredContacts()
		{
			List<Tuple<string, string>> contacts = new List<Tuple<string, string>>();

			for (int i = 0; i < npcContacts.Length; ++i)
			{
				if (npcContacts[i].isDiscovered)
				{
					contacts.Add(new Tuple<string, string>(npcContacts[i].identifier, npcContacts[i].numberString));
				}
			}

			contacts.Sort((contactA, contactB) => String.Compare(contactA.Item1, contactB.Item1));

			return contacts;
		}
	}
}