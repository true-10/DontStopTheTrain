
using DontStopTheTrain;
using UnityEngine;

namespace True10
{
    public class PlayAudioOnClick : BaseClickableView
    {
        [SerializeField]
        private AudioSource _audioSource;
        [SerializeField]
        private AudioClip _audioClipOnEnter;
        [SerializeField]
        private AudioClip _audioClipOnExit;

        protected override void OnClickViewHandler()
        {
            if (_audioClipOnEnter == null)
            {
                return;
            }
            _audioSource.PlayOneShot(_audioClipOnEnter);
        }

        protected override void OnExitViewHandler()
        {
            if (_audioClipOnExit == null)
            {
                return;
            }
            _audioSource.PlayOneShot(_audioClipOnExit);
        }
    }
}
