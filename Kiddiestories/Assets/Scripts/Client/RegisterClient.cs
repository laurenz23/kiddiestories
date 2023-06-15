using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;

namespace kiddiestories
{
    public class RegisterClient : MonoBehaviour
    {

        #region :: Variables
        [SerializeField] private Logger _logger;
        [Header("Firebase")]
        public DependencyStatus dependencyStatus;
        public FirebaseAuth auth;
        public FirebaseUser user;
        #endregion

        #region :: Listeners
        public delegate void ListenerRegisterSuccess(PlayerModel playerModel);
        public event ListenerRegisterSuccess EventRegisterSuccess;

        public delegate void ListenerRegisterSuccessWithError(string successWithErrorMessage);
        public event ListenerRegisterSuccessWithError EventRegisterSuccessWithError;

        public delegate void ListenerRegisterFailed(string failedMessage);
        public event ListenerRegisterFailed EventRegisterFailed;
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
        #endregion

        #region :: Methods
        public void Register(string email, string firstName, string lastName, string password)
        {
            StartCoroutine(IEnumRegister(email, firstName, lastName, password));
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
        private IEnumerator IEnumRegister(string email, string firstName, string lastName, string password)
        {
            if (auth == null)
                InitializeFirebase();

            // call the firebase auth signin function passing the email and password
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
            // wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                // if there are errors handle them
                _logger.Warning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
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

                EventRegisterFailed?.Invoke(message);
            }
            else
            {
                // user has now been created
                // now get the result
                user = RegisterTask.Result.User;

                if (user != null)
                {
                    string uuid = user.UserId;
                    PlayerModel playerProfile = new(
                    uuid,
                    email,
                    firstName,
                    lastName
                    );

                    EventRegisterSuccess?.Invoke(playerProfile);

                    // create user profile and set the username
                    UserProfile profile = new UserProfile { DisplayName = uuid };

                    // call the firebase auth update user profile function passing the profile with username
                    var ProfileTask = user.UpdateUserProfileAsync(profile);
                    // wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        // if there are errors handle them
                        _logger.Warning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        EventRegisterSuccessWithError?.Invoke($"Failed to register task with {ProfileTask.Exception}");
                    }
                    else
                    {
                        // username is now set
                        // new user can now login
                        yield return null;
                    }
                }
            }
        }
        #endregion

    }
}
