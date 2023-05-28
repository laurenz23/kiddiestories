using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            StartCoroutine(WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage.STORIES));
        }

        public void OnFavoritesAction()
        {
            StartCoroutine(WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage.FAVORITE));
        }

        public void OnQuizAction()
        {
            StartCoroutine(WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage.QUIZ));
        }

        public void OnGamesAction()
        {
            StartCoroutine(WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage.GAME));
        }

        public void OnDictionaryAction()
        {
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
