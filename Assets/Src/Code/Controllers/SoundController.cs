using UnityEngine;

namespace Assets.Src.Code.Controllers
{
    public class SoundController : MonoBehaviour
    {
        public static SoundController Instance { get; private set; }

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _click, _stretch, _win;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }

            Destroy(gameObject);
        }

        public void ClickSound() => _audioSource.PlayOneShot(_click);

        public void StretchSound() => _audioSource.PlayOneShot(_stretch);

        public void WinSound(float volume) => _audioSource.PlayOneShot(_win, volume);
    }
}