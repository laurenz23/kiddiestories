using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class HomeUIHandler : MonoBehaviour
    {

        #region :: Variables
        [SerializeField] private Animator _homeAnimator;

        private MainMenuUIHandler _mainMenuUIHandler;
        private readonly string _exit = "exit";
        private readonly float _delayTime = 2f;
        #endregion

        #region :: Life Cycle
        private void Start()
        {
            _mainMenuUIHandler = transform.parent.GetComponent<MainMenuUIHandler>();
        }
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
            _homeAnimator.SetTrigger(_exit);

            yield return new WaitForSeconds(_delayTime);
            _mainMenuUIHandler.DisplayPage(page);
            StopCoroutine(WaitForSecondToDisplay(MainMenuUIHandler.MainMenuPage.NULL));
        }
        #endregion 

    }
}
