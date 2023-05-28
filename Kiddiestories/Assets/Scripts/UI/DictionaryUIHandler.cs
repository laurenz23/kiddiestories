using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace kiddiestories
{
    public class DictionaryUIHandler : MainSubUIPanel
    {
        #region :: Variables
        [Header("Dictionary Attributes")]
        [SerializeField] private TMP_InputField _searchInputField;
        #endregion

        #region :: Actions
        public override void OnBackAction()
        {
            Reset();
            base.OnBackAction();
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
