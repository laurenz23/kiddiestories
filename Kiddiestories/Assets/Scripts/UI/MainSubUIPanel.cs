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

        [HideInInspector] public readonly string animEntry = "entry";
        [HideInInspector] public readonly string animExit = "exit";
        #endregion

        #region :: Actions
        public virtual void OnBackAction()
        {
            animator.SetTrigger(animExit);
            mainMenuUIHandler.BackWithDelay();
        }
        #endregion
    }
}
