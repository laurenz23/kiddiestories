using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using TMPro;

namespace kiddiestories
{
    public class DictionaryUIHandler : MainSubUIPanel
    {
        #region :: Variables
        [Header("Dictionary Attributes")]
        [SerializeField] private TMP_InputField _searchInputField;
        [SerializeField] private TMP_Text _searchDescription;
        [Header("Class reference")]
        [SerializeField] private RestClientManager _restClientManager;
        #endregion

        #region :: Life cycle
        public void OnEnable()
        {
            _restClientManager.EventWordDataSuccess += OnWordDataSuccess;
            _restClientManager.EventWordDataSuccessError += OnWordDataSuccessError;
            _restClientManager.EventWordDataError += OnWordDataError;
        }

        public void OnDisable()
        {
            _restClientManager.EventWordDataSuccess -= OnWordDataSuccess;
            _restClientManager.EventWordDataSuccessError -= OnWordDataSuccessError;
            _restClientManager.EventWordDataError -= OnWordDataError;
        }
        #endregion

        #region :: Events
        public void OnWordDataSuccess(DictionaryWordModel[] wordData)
        {
            string description = "";

            description += "Word: " + wordData[0].word + "\n";
            description += "Origin: " + wordData[0].origin + "\n\n";
            description += "Part of speech: " + wordData[0].meanings[0].partOfSpeech + "\n";
            description += "Meaning: " + wordData[0].meanings[0].definitions[0].definition + "\n";

            _searchDescription.text = description;
        }

        public void OnWordDataSuccessError()
        {
            _searchDescription.text = "Encountered an error while retrieving data";
        }

        public void OnWordDataError(RequestException error)
        {
            _searchDescription.text = error.ToString();
        }
        #endregion

        #region :: Actions
        public override void OnBackAction()
        {
            Reset();
            base.OnBackAction();
        }

        public void OnSearchTap()
        {
            string wordSearch = _searchInputField.text;
            _searchDescription.text = "Searching...";
            _restClientManager.RetrieveWordData(wordSearch);
        }
        #endregion

        #region :: Helper
        public void Reset()
        {
            _searchInputField.text = string.Empty;
        }
        #endregion
    }
}
