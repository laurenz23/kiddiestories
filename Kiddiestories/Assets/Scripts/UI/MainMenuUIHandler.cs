using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        [Header("Text")]
        [SerializeField] private TMP_Text _playerName;
        [Header("UI Panels")]
        public HomeUIHandler homeUIHandler;
        public OnBoardingUIHandler onBoardingUIHandler;
        public StoriesUIHandler storiesUIHandler;
        public FavoriteUIHandler favoriteUIHandler;
        public QuizUIHandler quizUIHandler;
        public GameUIHandler gameUIHandler;
        public DictionaryUIHandler dictionaryUIHandler;

        [Header("Managers")]
        public RepositoryManager repositoryManager;
        public SoundManager soundManager;

        private readonly float _delayTime = 1f;
        #endregion

        #region :: Life Cycle
        public void Start()
        {
            if (repositoryManager.LoadPlayerProfileData() != null)
            {
                string firstName = repositoryManager.GetPlayerProfileData().firstName;
                string lastName = repositoryManager.GetPlayerProfileData().lastName;
                _playerName.text = firstName + " " + lastName;
            }

            DisplayPage(MainMenuPage.HOME);
        }
        #endregion

        #region :: Actions
        public void OnLogoutAction()
        {
            soundManager.soundFXManager.PlayUITap("tap2");
            repositoryManager.DeletePlayerProfileData();
            onBoardingUIHandler.loginUIHandler.gameObject.SetActive(true);
            onBoardingUIHandler.gameObject.SetActive(true);
        }
        #endregion

        #region :: Helper
        public void BackWithDelay()
        {
            StartCoroutine(WaitForSecondToBack());
        }

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

        private IEnumerator WaitForSecondToBack()
        {
            yield return new WaitForSeconds(_delayTime);
            DisplayPage(MainMenuPage.HOME);
            StopCoroutine(WaitForSecondToBack());
        }
        #endregion

    }
}
