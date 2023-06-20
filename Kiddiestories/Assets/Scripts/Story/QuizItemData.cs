using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace kiddiestories
{
    [CreateAssetMenu(fileName = "New QA data", menuName = "Kiddiestories/QA data")]
    [System.Serializable]
    public class QuizItemData : ScriptableObject
    {

        [SerializeField] private new string name;

        [TextArea]
        [SerializeField] private string _description;

        [SerializeField] private string _answer;

        [SerializeField] private List<string> _choiceList;

#if UNITY_EDITOR
        private void OnValidate()
        {
            name = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this)).ToLower();
        }
#endif

        public string GetName()
        {
            return name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public string GetAnswer()
        {
            return _answer;
        }

        public List<string> GetChoiceList()
        {
            return _choiceList;
        }

    }
}
