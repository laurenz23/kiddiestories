using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Proyecto26;

namespace kiddiestories
{
    public class RegisterUIHandler : MonoBehaviour
    {

        [SerializeField] private TMP_InputField _emailInputField;
        [SerializeField] private TMP_InputField _firstNameInputField;
        [SerializeField] private TMP_InputField _lastNameInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        [SerializeField] private TMP_InputField _confirmPasswordInputField;
        [SerializeField] private TMP_Text _errorMessage;
        [SerializeField] private GameObject _errorPanel;
        [Header("Class Reference")]
        [SerializeField] private OnBoardingUIHandler _onBoardingUIHandler;
        [SerializeField] private RegisterClient _registerClient;
        [SerializeField] private RestClientManager _restClientManager;

        private void OnEnable()
        {
            _registerClient.EventRegisterSuccess += OnRegisterSuccess;
            _registerClient.EventRegisterSuccessWithError += OnRegisterSuccessError;
            _registerClient.EventRegisterFailed += OnRegisterFailed;

            _restClientManager.EventPlayerDataSuccess += OnPlayerDataSuccess;
            _restClientManager.EventPlayerDataSuccessError += OnPlayerDataSuccessError;
            _restClientManager.EventPlayerDataError += OnPlayerDataError;
        }

        private void OnDisable()
        {
            _registerClient.EventRegisterSuccess -= OnRegisterSuccess;
            _registerClient.EventRegisterSuccessWithError -= OnRegisterSuccessError;
            _registerClient.EventRegisterFailed -= OnRegisterFailed;

            _restClientManager.EventPlayerDataSuccess -= OnPlayerDataSuccess;
            _restClientManager.EventPlayerDataSuccessError -= OnPlayerDataSuccessError;
            _restClientManager.EventPlayerDataError -= OnPlayerDataError;
        }

        private void OnPlayerDataSuccess(PlayerModel playerData)
        {
            Debug.Log("Player Model: " + playerData.email);
            _onBoardingUIHandler.loginUIHandler.gameObject.SetActive(true);
            _onBoardingUIHandler.registerUIHandler.gameObject.SetActive(false);
            Reset();
        }

        private void OnPlayerDataSuccessError()
        {
            _errorMessage.text = "Encountered an error while saving player data.";
            _errorPanel.SetActive(true);
        }

        private void OnPlayerDataError(RequestException error)
        {
            _errorMessage.text = error.ToString();
            _errorPanel.SetActive(true);
        }

        private void OnRegisterSuccess(PlayerModel playerData)
        {
            _restClientManager.Register(playerData.uuid, playerData);
        }

        private void OnRegisterSuccessError(string successWithErrorMessage)
        {
            _errorMessage.text = successWithErrorMessage;
            _errorPanel.SetActive(true);
        }

        private void OnRegisterFailed(string failedMessage)
        {
            _errorMessage.text = failedMessage;
            _errorPanel.SetActive(true);
        }

        public void OnBackToLogin()
        {
            _onBoardingUIHandler.soundManager.soundFXManager.PlayUITap("tap1");
            _onBoardingUIHandler.loginUIHandler.gameObject.SetActive(true);
            _onBoardingUIHandler.registerUIHandler.gameObject.SetActive(false);
            Reset();
        }

        public void OnRegisterUser()
        {
            _onBoardingUIHandler.soundManager.soundFXManager.PlayUITap("tap1");
            string email = _emailInputField.text;
            string firstName = _firstNameInputField.text;
            string lastName = _lastNameInputField.text;
            string password = _passwordInputField.text;
            string confirmPassword = _confirmPasswordInputField.text;
            List<string> errorMessageList = new();

            if (email.Equals(string.Empty))
            {
                errorMessageList.Add("• Please enter your email");
            }

            if (firstName.Equals(string.Empty))
            {
                errorMessageList.Add("• Please enter your first name");
            }

            if (lastName.Equals(string.Empty))
            {
                errorMessageList.Add("• Please enter your last name");
            }

            if (password.Equals(string.Empty))
            {
                errorMessageList.Add("• Please enter your password");
            }

            if (confirmPassword.Equals(string.Empty))
            {
                errorMessageList.Add("• Please confirm your password");
            }

            if (!password.Equals(confirmPassword)) 
            {
                errorMessageList.Add("• Password did not match");
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
                _registerClient.Register(email, firstName, lastName, password);
            }
        }

        private void Reset()
        {
            _emailInputField.text = string.Empty;
            _firstNameInputField.text = string.Empty;
            _lastNameInputField.text = string.Empty;
            _passwordInputField.text = string.Empty;
            _confirmPasswordInputField.text = string.Empty;
            _errorMessage.text = "";
            _errorPanel.SetActive(false);
        }

    }
}
