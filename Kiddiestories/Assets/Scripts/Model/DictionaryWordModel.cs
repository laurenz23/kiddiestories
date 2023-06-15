using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DictionaryWordModel
{
    public string word;
    public string phonetic;
    public string origin;
    public DictionaryMeaningModel[] meanings;
}
