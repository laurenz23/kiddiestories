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

        private readonly string dictionaryApiUrl = "https://api.dictionaryapi.dev/api/v2/entries/en/";
        private readonly Dictionary<string, string> headers = new() { { "Authorization", "Other token..." } };

        public delegate void OnDictionaryDataSuccess(DictionaryWordModel[] wordData);
        public event OnDictionaryDataSuccess EventWordDataSuccess;

        public delegate void OnDictionaryDataSuccessError();
        public event OnDictionaryDataSuccessError EventWordDataSuccessError;

        public delegate void OnDictionaryDataError(RequestException error);
        public event OnDictionaryDataError EventWordDataError;

        public void RetrieveWordData(string word)
        {
            Debug.Log("Retrieving Data");
            RestClient.GetArray<DictionaryWordModel>(dictionaryApiUrl + $"{word}")
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

    }
}
