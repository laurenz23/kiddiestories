using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class MainSubUIPanel : MonoBehaviour
    {
        #region :: Variables
        [Header("Main Sub UI Attributes")]
        public MainMenuUIHandler mainMenuUIHandler;
        public Animator animator;

        [HideInInspector] public SoundFXManager soundFXManager; 
        [HideInInspector] public readonly string animEntry = "entry";
        [HideInInspector] public readonly string animExit = "exit";
        #endregion

        #region :: Life Cycle
        private void Awake()
        {
            soundFXManager = mainMenuUIHandler.soundManager.soundFXManager;
        }
        #endregion

        #region :: Actions
        public virtual void OnBackAction()
        {
            soundFXManager.PlayUITap("tap2");
            animator.SetTrigger(animExit);
            mainMenuUIHandler.BackWithDelay();
        }
        #endregion
    }
}
