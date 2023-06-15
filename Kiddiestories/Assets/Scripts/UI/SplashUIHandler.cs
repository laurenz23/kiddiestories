using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class SplashUIHandler : MonoBehaviour
    {

        [SerializeField] private RepositoryManager _repositoryManager;
        [SerializeField] private MainMenuUIHandler _mainMenuUIHandler;
        [SerializeField] private OnBoardingUIHandler _onBoardingUIHandler;

        private void Start()
        {
            if (_repositoryManager.LoadPlayerProfileData() == null)
            {
                _onBoardingUIHandler.gameObject.SetActive(true);
                _onBoardingUIHandler.loginUIHandler.gameObject.SetActive(true);
            }
            else 
            {
                _mainMenuUIHandler.gameObject.SetActive(true);
                _mainMenuUIHandler.homeUIHandler.gameObject.SetActive(true);
            }

            gameObject.SetActive(false);
        }

    }
}
