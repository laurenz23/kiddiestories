using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Auth;
using System;

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

        private void OnEnable()
        {
            _loginClient.EventLoginSuccess += OnLoginSuccess;
            _loginClient.EventLoginFailed += OnLoginFailed;
        }

        private void OnLoginSuccess(FirebaseUser user)
        {
            _onBoardingUIHandler.mainMenuUIHandler.gameObject.SetActive(true);
            _onBoardingUIHandler.gameObject.SetActive(false);
        }

        private void OnLoginFailed(string failedMessage)
        {
            _errorMessage.text = failedMessage;
            _errorPanel.SetActive(true);
        }


        private void OnDisable()
        {
            _loginClient.EventLoginSuccess -= OnLoginSuccess;
            _loginClient.EventLoginFailed -= OnLoginFailed;
        }

        public void OnLoginTap()
        {
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
            _onBoardingUIHandler.registerUIHandler.gameObject.SetActive(true);
            _onBoardingUIHandler.loginUIHandler.gameObject.SetActive(true);
        }

    }
}
