using UnityEngine;

namespace Artistas
{
	[CreateAssetMenu(fileName = "NewNPC", menuName = "Artistas/NPC/New NPC")]
	public class NPC : ScriptableObject
	{
		[Header("General Info")]
		public string identifier;
		public string numberString;
		public bool isDiscovered; // An NPC is discovered on a successful call.

		public void UnlockContact()
        {
			isDiscovered = true;
        }
	}
}