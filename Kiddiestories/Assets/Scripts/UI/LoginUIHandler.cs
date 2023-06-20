using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Auth;
using System;
using Proyecto26;

namespace kiddiestories
{
    public class LoginUIHandler : MonoBehaviour
    {

        [SerializeField] private TMP_InputField _emailInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        [SerializeField] private TMP_Text _errorMessage;
        [SerializeField] private GameObject _errorPanel;
        [Header("Class Reference")]
        [SerializeField] private OnBoardingUIHandler _onBoardingUIHandler;
        [SerializeField] private LoginClient _loginClient;
        [SerializeField] private RestClientManager _restClientManager;
        [SerializeField] private RepositoryManager _repositoryManager;

        private void OnEnable()
        {
            _loginClient.EventLoginSuccess += OnLoginSuccess;
            _loginClient.EventLoginFailed += OnLoginFailed;

            _restClientManager.EventPlayerDataSuccess += OnPlayerDataSuccess;
            _restClientManager.EventPlayerDataSuccessError += OnPlayerDataSuccessError;
            _restClientManager.EventPlayerDataError += OnPlayerDataError;
        }

        private void OnDisable()
        {
            _loginClient.EventLoginSuccess -= OnLoginSuccess;
            _loginClient.EventLoginFailed -= OnLoginFailed;

            _restClientManager.EventPlayerDataSuccess -= OnPlayerDataSuccess;
            _restClientManager.EventPlayerDataSuccessError -= OnPlayerDataSuccessError;
            _restClientManager.EventPlayerDataError -= OnPlayerDataError;
        }

        private void OnPlayerDataSuccess(PlayerModel playerData)
        {
            Debug.Log("This is working 2", this);
            _repositoryManager.SavePlayerProfileData(playerData);

            if (_repositoryManager.LoadPlayerProfileData() == null)
            {
                _errorMessage.text = "Encountered an error loading data.";
                _errorPanel.SetActive(true);
                return;
            }

            _onBoardingUIHandler.mainMenuUIHandler.gameObject.SetActive(true);
            _onBoardingUIHandler.gameObject.SetActive(false);
            _emailInputField.text = string.Empty;
            _passwordInputField.text = string.Empty;
        }

        private void OnPlayerDataSuccessError()
        {
            _errorMessage.text = "Encountered an error retrieving data.";
            _errorPanel.SetActive(true);
        }

        private void OnPlayerDataError(RequestException error)
        {
            _errorMessage.text = error.ToString();
            _errorPanel.SetActive(true);
        }

        private void OnLoginSuccess(FirebaseUser user)
        {
            Debug.Log("This is working", this);
            _restClientManager.RetrievePlayerData(user.UserId);
        }

        private void OnLoginFailed(string failedMessage)
        {
            _errorMessage.text = failedMessage;
            _errorPanel.SetActive(true);
        }

        public void OnLoginTap()
        {
            _onBoardingUIHandler.soundManager.soundFXManager.PlayUITap("tap1");

            string email = _emailInputField.text;
            string password = _passwordInputField.text;
            List<string> errorMessageList = new();

            if (email.Equals(string.Empty))
            {
                errorMessageList.Add("• Please enter your email");
            }

            if (password.Equals(string.Empty))
            {
                errorMessageList.Add("• Please enter your password");
            }

            if (errorMessageList.Count > 0)
            {
                string errorMessage = "";

                foreach (string message in errorMessageList)
                {
                    errorMessage += message + "\n";
                }

                _errorMessage.text = errorMessage;
                _errorPanel.SetActive(true);
            }
            else
            {
                _errorMessage.text = "";
                _errorPanel.SetActive(false);
                _loginClient.Login(email, password);
            }
        }

        public void OnRegisterTap()
        {
            _onBoardingUIHandler.soundManager.soundFXManager.PlayUITap("tap1");
            _onBoardingUIHandler.registerUIHandler.gameObject.SetActive(true);
            _onBoardingUIHandler.loginUIHandler.gameObject.SetActive(false);
            Reset();
        }

        private void Reset()
        {
            _emailInputField.text = string.Empty;
            _passwordInputField.text = string.Empty;
            _errorMessage.text = "";
            _errorPanel.SetActive(false);
        }

    }
}
