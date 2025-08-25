using UnityEngine;
using UnityEngine.UI;

namespace MyGame.UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonSound : MonoBehaviour
    {
        [Header("Ouvido")]
        public AudioClip clickSound;
        [Range(0f, 1f)]
        public float volume = 1f;

        private AudioSource audioSource;

        void Awake()
        {
           
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
            }

            
            GetComponent<Button>().onClick.AddListener(PlayClickSound);
        }

        void PlayClickSound()
        {
            if (clickSound != null)
                audioSource.PlayOneShot(clickSound, volume);
        }
    }
}
