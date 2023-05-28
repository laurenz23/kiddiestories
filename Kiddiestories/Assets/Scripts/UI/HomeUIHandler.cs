using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class HomeUIHandler : MonoBehaviour
    {

        #region :: Variables
        private MainMenuUIHandler mainMenuUIHandler;
        #endregion

        #region :: Life Cycle
        private void Start()
        {
            mainMenuUIHandler = transform.parent.GetComponent<MainMenuUIHandler>();
        }
        #endregion

        #region :: Actions
        public void OnStoriesAction()
        {
            mainMenuUIHandler.DisplayPage(MainMenuUIHandler.MainMenuPage.STORIES);
        }

        public void OnFavoritesAction()
        {
            mainMenuUIHandler.DisplayPage(MainMenuUIHandler.MainMenuPage.FAVORITE);
        }

        public void OnQuizAction()
        {
            mainMenuUIHandler.DisplayPage(MainMenuUIHandler.MainMenuPage.QUIZ);
        }

        public void OnGamesAction()
        {
            mainMenuUIHandler.DisplayPage(MainMenuUIHandler.MainMenuPage.GAME);
        }

        public void OnDictionaryAction()
        {
            mainMenuUIHandler.DisplayPage(MainMenuUIHandler.MainMenuPage.DICTIONARY);
        }
        #endregion

    }
}
