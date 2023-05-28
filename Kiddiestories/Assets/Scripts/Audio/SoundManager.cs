using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class SoundManager : MonoBehaviour
    {
        //private RepositoryManager repositoryManager;
        //private PlayerSettingsModel soundSettingsData = new();

        // soundFX reference
        public SoundFXManager soundFXManager;
        private bool soundFX_enabled;

        private static SoundManager instance;

        public static SoundManager GetInstance()
        {
            return instance;
        }

        #region :: Lifecycle
        private void Awake()
        {
            if (instance == null)
                instance = this;

            //repositoryManager = RepositoryManager.GetInstance();
        }

        private void Start()
        {
            //soundSettingsData = repositoryManager.GetPlayerSettingsData();

            //SetMusic(soundSettingsData.isMusicEnable);
            SetSoundFX(true);
        }
        #endregion

        #region :: Properties
        //public bool IsMusicEnable()
        //{
        //    return music_enabled;
        //}

        public bool IsSoundFXEnable()
        {
            return soundFX_enabled;
        }
        #endregion

        #region :: Methods
        // set music if enabled or disabled
        //public void SetMusic(bool isEnabled)
        //{
        //    music_enabled = isEnabled;

        //    AudioSource[] audioSourceList = musicHandler.transform.GetComponents<AudioSource>();

        //    if (music_enabled)
        //    {
        //        foreach (AudioSource a in audioSourceList)
        //        {
        //            a.mute = false;
        //        }
        //    }
        //    else
        //    {
        //        foreach (AudioSource a in audioSourceList)
        //        {
        //            a.mute = true;
        //        }
        //    }
        //}

        // set soundFX if enabled or disabled
        public void SetSoundFX(bool isEnabled)
        {
            soundFX_enabled = isEnabled;

            AudioSource[] audioSourceList = soundFXManager.transform.GetComponents<AudioSource>();

            if (soundFX_enabled)
            {
                foreach (AudioSource a in audioSourceList)
                {
                    a.mute = false;
                }
            }
            else
            {
                foreach (AudioSource a in audioSourceList)
                {
                    a.mute = true;
                }
            }
        }
        #endregion
    }
}
