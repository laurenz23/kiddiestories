using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace kiddiestories
{
    public class HomeUIHandler : MainSubUIPanel
    {

        #region :: Variables
        private readonly float _delayTime = 2f;
        #endregion

        #region :: Actions
        public void OnStoriesAction()
        {
            soundFXManager.PlayUITap("tap1");
            StartCoroutine(WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage.STORIES));
        }

        public void OnFavoritesAction()
        {
            soundFXManager.PlayUITap("tap1");
            StartCoroutine(WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage.FAVORITE));
        }

        public void OnQuizAction()
        {
            soundFXManager.PlayUITap("tap1");
            StartCoroutine(WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage.QUIZ));
        }

        public void OnGamesAction()
        {
            soundFXManager.PlayUITap("tap1");
            StartCoroutine(WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage.GAME));
        }

        public void OnDictionaryAction()
        {
            soundFXManager.PlayUITap("tap1");
            StartCoroutine(WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage.DICTIONARY));
        }
        #endregion

        #region :: Helper
        public IEnumerator WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage page)
        {
            animator.SetTrigger(animExit);

            yield return new WaitForSeconds(_delayTime);
            mainMenuUIHandler.DisplayPage(page);
            StopCoroutine(WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage.NULL));
        }
        #endregion 

    }
}
