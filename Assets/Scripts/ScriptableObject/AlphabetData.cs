using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class AlphabetData : ScriptableObject
{
    [System.Serializable]
    public class LetterData
    {
        public string letter;
        public Sprite image;
    }

    public List<LetterData> AlphaBetPlane = new List<LetterData>();
    public List<LetterData> AlphaBetNormal = new List<LetterData>();
    public List<LetterData> AlphaBetHighlighted = new List<LetterData>();
    public List<LetterData> AlphaBetWrong = new List<LetterData>();

}  
