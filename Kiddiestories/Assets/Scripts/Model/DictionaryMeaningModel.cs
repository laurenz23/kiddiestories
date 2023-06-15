using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DictionaryMeaningModel
{
    public string partOfSpeech;
    public DefinitionModel[] definitions;
}

[System.Serializable]
public class DefinitionModel
{
    public string definition;
    public string example;
}
