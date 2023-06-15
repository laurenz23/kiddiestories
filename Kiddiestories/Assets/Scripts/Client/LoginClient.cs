using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;

namespace kiddiestories
{
    public class LoginClient : MonoBehaviour
    {
        #region :: Variables
        [SerializeField] private Logger _logger;
        [Header("Firebase")]
        public DependencyStatus dependencyStatus;
        public FirebaseAuth auth;
        public FirebaseUser user;
        #endregion

        #region :: Listeners
        public delegate void ListenerLoginSuccess(FirebaseUser user);
        public event ListenerLoginSuccess EventLoginSuccess;

        public delegate void ListenerLoginFailed(string failedMessage);
        public event ListenerLoginFailed EventLoginFailed;

        public delegate void ListenerForgotPasswordSuccess(string successMessage);
        public event ListenerForgotPasswordSuccess EventForgotPasswordSuccess;

        public delegate void ListenerForgotPasswordFailed(string failedMessage);
        public event ListenerForgotPasswordFailed EventForgotPasswordFailed;
        #endregion

        #region :: Lifecycle
        private void Awake()
        {
            // Check all the necessary dependencies for firebase are present on the system
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    // if they are available initialize firebase
                    InitializeFirebase();
                }
                else
                {
                    _logger.Error("Could not resolve all Firebase dependencies: " + dependencyStatus);
                }
            });
        }

        private void Start()
        {
            if (auth == null)
            {
                // Check all the necessary dependencies for firebase are present on the system
                FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
                {
                    dependencyStatus = task.Result;
                    if (dependencyStatus == DependencyStatus.Available)
                    {
                        // if they are available initialize firebase
                        InitializeFirebase();
                    }
                    else
                    {
                        _logger.Error("Could not resolve all Firebase dependencies: " + dependencyStatus);
                    }
                });
            }
        }
        #endregion

        #region :: Methods
        public void Login(string email, string password)
        {
            StartCoroutine(IEnumLogin(email, password));
        }

        public void ForgotPassword(string email)
        {
            auth.SendPasswordResetEmailAsync(email).ContinueWithOnMainThread(task => {
                if (task.IsCanceled)
                    EventForgotPasswordFailed?.Invoke("Reset Password Canceled");

                if (task.IsFaulted)
                {
                    foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                    {
                        if (exception is FirebaseException firebaseEx)
                        {
                            string message = "";
                            var errorCode = (AuthError)firebaseEx.ErrorCode;

                            switch (errorCode)
                            {
                                case AuthError.MissingEmail:
                                    message = "Missing Email!";
                                    break;
                                case AuthError.MissingPassword:
                                    message = "Missing Password!";
                                    break;
                                case AuthError.WrongPassword:
                                    message = "Wrong Password";
                                    break;
                                case AuthError.InvalidEmail:
                                    message = "Invalid Email!";
                                    break;
                                case AuthError.UserNotFound:
                                    message = "User Not Found!";
                                    break;
                            }

                            EventForgotPasswordFailed?.Invoke(message);
                        }
                    }
                }

                EventForgotPasswordSuccess?.Invoke("Successfully changed password");
            });
        }
        #endregion

        #region :: Helper
        private void InitializeFirebase()
        {
            // set authentication instance object
            auth = FirebaseAuth.DefaultInstance;
        }
        #endregion

        #region :: Enumerator
        private IEnumerator IEnumLogin(string email, string password)
        {
            // call the firebase auth signin function passing the email and password
            var LoginTask = auth.SignInWithEmailAndPasswordAsync(email, password);
            // wait until the task completes
            yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

            if (LoginTask.Exception != null)
            {
                // if there are errors handle them
                _logger.Warning(message: $"Failed to register task with {LoginTask.Exception}");
                FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Login Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email!";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password!";
                        break;
                    case AuthError.WrongPassword:
                        message = "Wrong Password";
                        break;
                    case AuthError.InvalidEmail:
                        message = "Invalid Email!";
                        break;
                    case AuthError.UserNotFound:
                        message = "User Not Found!";
                        break;
                }

                _logger.Warning(message);
                EventLoginFailed?.Invoke(message);
            }
            else
            {
                // user is not logged in
                // now get the result
                user = LoginTask.Result.User;
                EventLoginSuccess?.Invoke(user);
            }
        }
        #endregion
    }
}
