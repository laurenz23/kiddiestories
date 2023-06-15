using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

        public void OnBackToLogin()
        {
            _onBoardingUIHandler.loginUIHandler.gameObject.SetActive(true);
            _onBoardingUIHandler.registerUIHandler.gameObject.SetActive(false);
        }

        public void OnRegisterUser()
        {
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
                _onBoardingUIHandler.mainMenuUIHandler.gameObject.SetActive(true);
            }

            _onBoardingUIHandler.loginUIHandler.gameObject.SetActive(true);
            _onBoardingUIHandler.registerUIHandler.gameObject.SetActive(false);
        }

    }
}
