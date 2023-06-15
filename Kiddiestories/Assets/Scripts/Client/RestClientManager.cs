using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

namespace kiddiestories
{
    public class RestClientManager : MonoBehaviour
    {

        public enum RestAPIMethod
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        private readonly string _restApiUrl = "https://kiddiestories-6b58b-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private readonly Dictionary<string, string> _headers = new() { { "Authorization", "Other token..." } };
        private static readonly string _contentType = ".json";

        private readonly string _dictionaryApiUrl = "https://api.dictionaryapi.dev/api/v2/entries/en/";

        #region :: Player Profile Data
        public delegate void OnPlayerDataSuccess(PlayerModel playerData);
        public event OnPlayerDataSuccess EventPlayerDataSuccess;

        public delegate void OnPlayerDataSuccessError();
        public event OnPlayerDataSuccessError EventPlayerDataSuccessError;

        public delegate void OnPlayerDataError(RequestException error);
        public event OnPlayerDataError EventPlayerDataError;

        public void Register(string uuid, PlayerModel playerData)
        {
            RestClient.Request(
                new RequestHelper
                {
                    Uri = _restApiUrl + $"{uuid}" + _contentType,
                    Method = RestAPIMethod.PUT.ToString(),
                    Body = playerData,
                    Headers = _headers
                }).Then(
                response => {
                    if (response != null)
                        EventPlayerDataSuccess?.Invoke(playerData);
                    else
                        EventPlayerDataSuccessError?.Invoke();
                }).Catch(
                error => {
                    EventPlayerDataError?.Invoke(error as RequestException);
                });
        }

        public void RetrievePlayerData(string uuid)
        {
            RestClient.Get<PlayerModel>(_restApiUrl + $"{uuid}" + _contentType)
                .Then(
                response =>
                {
                    Debug.Log("Success Retrieving Data: " + response);
                    if (response != null)
                        EventPlayerDataSuccess?.Invoke(response);
                    else
                        EventPlayerDataSuccessError?.Invoke();
                })
                .Catch(
                error => {
                    Debug.Log("Error Retrieving Data: " + (error as RequestException));
                    EventPlayerDataError?.Invoke(error as RequestException);
                });
        }
        #endregion

        #region :: Dictionary Word Data
        public delegate void OnDictionaryDataSuccess(DictionaryWordModel[] wordData);
        public event OnDictionaryDataSuccess EventWordDataSuccess;

        public delegate void OnDictionaryDataSuccessError();
        public event OnDictionaryDataSuccessError EventWordDataSuccessError;

        public delegate void OnDictionaryDataError(RequestException error);
        public event OnDictionaryDataError EventWordDataError;

        public void RetrieveWordData(string word)
        {
            Debug.Log("Retrieving Data");
            RestClient.GetArray<DictionaryWordModel>(_dictionaryApiUrl + $"{word}")
                .Then(
                response =>
                {
                    if (response != null)
                        EventWordDataSuccess?.Invoke(response);
                    else
                        EventWordDataSuccessError?.Invoke();
                })
                .Catch(
                error =>
                {
                    Debug.Log("Error Retrieving Data: " + (error as RequestException));
                    EventWordDataError?.Invoke(error as RequestException);
                });
        }
        #endregion

    }
}
