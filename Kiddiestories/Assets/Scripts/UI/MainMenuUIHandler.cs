using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class MainMenuUIHandler : MonoBehaviour
    {

        public enum MainMenuPage
        { 
            NULL,
            DICTIONARY,
            FAVORITE,
            GAME,
            HOME,
            QUIZ,
            STORIES
        }

        #region :: Variables
        public HomeUIHandler homeUIHandler;
        public StoriesUIHandler storiesUIHandler;
        public FavoriteUIHandler favoriteUIHandler;
        public QuizUIHandler quizUIHandler;
        public GameUIHandler gameUIHandler;
        public DictionaryUIHandler dictionaryUIHandler;
        #endregion

        #region :: Life Cycle
        public void Start()
        {
            DisplayPage(MainMenuPage.HOME);
        }
        #endregion

        #region :: Helper
        public void DisplayPage(MainMenuPage page)
        {
            homeUIHandler.gameObject.SetActive(false);
            storiesUIHandler.gameObject.SetActive(false);
            favoriteUIHandler.gameObject.SetActive(false);
            quizUIHandler.gameObject.SetActive(false);
            gameUIHandler.gameObject.SetActive(false);
            dictionaryUIHandler.gameObject.SetActive(false);

            switch (page)
            {
                case MainMenuPage.DICTIONARY: 
                    dictionaryUIHandler.gameObject.SetActive(true);
                    break;
                case MainMenuPage.FAVORITE:
                    favoriteUIHandler.gameObject.SetActive(true);
                    break;
                case MainMenuPage.GAME:
                    gameUIHandler.gameObject.SetActive(true);
                    break;
                case MainMenuPage.HOME:
                    homeUIHandler.gameObject.SetActive(true);
                    break;
                case MainMenuPage.QUIZ:
                    quizUIHandler.gameObject.SetActive(true);
                    break;
                case MainMenuPage.STORIES:
                    storiesUIHandler.gameObject.SetActive(true);
                    break;
            }
        }
        #endregion

    }
}
