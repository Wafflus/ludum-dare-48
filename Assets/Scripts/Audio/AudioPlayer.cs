using UnityEngine;

namespace Artistas
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        [Header("Sounds")]
        [SerializeField] private SoundListSO soundList;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayRandomSound()
        {
            AudioClip audioClip = soundList.GetRandomSound();

            audioSource.clip = audioClip;

            audioSource.loop = soundList.shouldLoopSounds;

            audioSource.Play();
        }

        public void PlaySoundAtIndex(int index)
        {
            if (soundList.sounds.Length <= index)
            {
                return;
            }

            AudioClip audioClip = soundList.GetSoundAtIndex(index);

            audioSource.clip = audioClip;

            audioSource.loop = soundList.shouldLoopSounds;

            audioSource.Play();
        }

        public void StopSound()
        {
            if (audioSource.clip == null)
            {
                return;
            }

            audioSource.Stop();
        }
    }
}