using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
                _onBoardingUIHandler.mainMenuUIHandler.gameObject.SetActive(true);
                _onBoardingUIHandler.gameObject.SetActive(false);
            }
        }

        public void OnRegisterTap()
        {
            _onBoardingUIHandler.registerUIHandler.gameObject.SetActive(true);
            _onBoardingUIHandler.loginUIHandler.gameObject.SetActive(true);
        }

    }
}
