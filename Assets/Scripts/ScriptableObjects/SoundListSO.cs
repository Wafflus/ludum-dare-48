using UnityEngine;

namespace Artistas
{
	[CreateAssetMenu(fileName = "NewSoundList", menuName = "Artistas/Sounds/New Sound List")]
	public class SoundListSO : ScriptableObject
	{
		public AudioClip[] sounds;

		public bool shouldLoopSounds = false;

		public AudioClip GetRandomSound()
		{
			int randomSoundIndex = Random.Range(0, sounds.Length);

			return sounds[randomSoundIndex];
		}

		public AudioClip GetSoundAtIndex(int index)
        {
			return sounds[index];
        }
	}
}