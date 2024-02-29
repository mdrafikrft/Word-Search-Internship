using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    //OnEnable
    public delegate void EnableSquarrSelection();
    public static event EnableSquarrSelection OnEnableSquarrSelection;
    public static void EnableSquarrSelectionMethod()
    {
        if(OnEnableSquarrSelection != null)
        {
            OnEnableSquarrSelection();
        }
    }

    //OnDisable
    public delegate void DisableSquarrSelection();
    public static event DisableSquarrSelection OnDisableSquarrSelection;
    public static void DisableSquarrSelectionMethod()
    {
        if (OnDisableSquarrSelection != null)
        {
            OnDisableSquarrSelection();
        }
    }

    //OnSelection
    public delegate void SelectSquare (Vector3 position);
    public static event SelectSquare OnSelectSquare;
    public static void SelectSquareMethod(Vector3 position)
    {
        if (OnSelectSquare != null)
        {
            OnSelectSquare(position);
        }
    }

    //OnCheck
    public delegate void CheckSquare(string letter, Vector3 squarePosition, int squareIndex);
    public static event CheckSquare OnCheckSquare;
    public static void CheckSquareMethod(string letter, Vector3 squarePosition, int squareIndex)
    {
        if (OnCheckSquare != null)
        {
            OnCheckSquare(letter, squarePosition, squareIndex);
        }
    }

    //OnClearSelection
    public delegate void ClearSelection();
    public static event ClearSelection OnClearSelection;
    public static void ClearSelectionMethod()
    {
        if (OnClearSelection != null)
        {
            OnClearSelection();
        }
    }
    
    //CorrectWord Event
    public delegate void CorrectWord(string word, List<int> squareIndexes);
    public static event CorrectWord OnCorrectWord;

    public static void CorrectWordMethod(string word, List<int> squareIndexes)
    {
        if(OnCorrectWord != null)
        {
            OnCorrectWord(word, squareIndexes);
        }
    }
}
