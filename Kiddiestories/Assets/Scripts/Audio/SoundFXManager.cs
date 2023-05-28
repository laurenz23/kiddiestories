using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class SoundFXManager : MonoBehaviour
    {
        [SerializeField] private AudioModel[] _sfxUITap;

        private Logger _logger;

        private void Awake()
        {
            SoundDataDistribute(_sfxUITap);

        }

        private void Start()
        {
            _logger = GetComponent<Logger>();
        }

        private void SoundDataDistribute(AudioModel[] audioDataArray)
        {
            foreach (AudioModel a in audioDataArray)
            {
                a.audioSource = gameObject.AddComponent<AudioSource>();
                a.audioSource.clip = a.audioClip;
                a.audioSource.mute = a.mute;
                a.audioSource.loop = a.loop;
                a.audioSource.volume = a.volume;
                a.audioSource.pitch = a.pitch;
            }
        }

        private void PlaySound(AudioModel[] audioDataArray, string name)
        {
            AudioModel a = Array.Find(audioDataArray, audioData => audioData.audioName == name);

            if (a == null)
            {
#if UNITY_EDITOR
                _logger.Warning("SoundFX " + name + " sound not found.", this);
#endif
                return;
            }

            a.audioSource.PlayOneShot(a.audioClip);
        }

        public void PlayUITap(string name)
        {
            PlaySound(_sfxUITap, name);
        }
    }
}
