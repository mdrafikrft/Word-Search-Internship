using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquare : MonoBehaviour
{
    public int SquareIndex { get; set; }

    private AlphabetData.LetterData _normalLetterData;
    private AlphabetData.LetterData _selectedLetterData;
    private AlphabetData.LetterData _correctLetterData;

    private SpriteRenderer _displayedImage;

    private bool _selected;
    private bool _clicked;
    private int _index = -1;
    private bool _correct;

    public void SetIndex(int index)
    {
        _index = index;
    }

    public int GetIndex()
    {
        return _index;
    }

    void Start()
    {
        _selected = false;
        _clicked = false;
        _correct = false;
        _displayedImage = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        GameEvents.OnEnableSquarrSelection += OnEnableSquareSelection;
        GameEvents.OnDisableSquarrSelection += OnDisableSquarrSelection;
        GameEvents.OnSelectSquare += SelectSquare;
    }

    private void OnDisable()
    {
        GameEvents.OnEnableSquarrSelection -= OnEnableSquareSelection;
        GameEvents.OnDisableSquarrSelection -= OnDisableSquarrSelection;
        GameEvents.OnSelectSquare -= SelectSquare;
    }

    public void OnEnableSquareSelection()
    {
        _clicked = true;
        _selected = false;
    }

    public void OnDisableSquarrSelection()
    {
        _selected = false;
        _clicked = false;

        if(_correct == true)
        {
            _displayedImage.sprite = _correctLetterData.image;
        }
        else
        {
            _displayedImage.sprite = _normalLetterData.image;
        }
    }

    private void SelectSquare(Vector3 position)
    {
        if(this.gameObject.transform.position == position)
        {
            _displayedImage.sprite = _selectedLetterData.image;
        }
    }

    public void SetSprite(AlphabetData.LetterData normalLetterData, AlphabetData.LetterData selectedLetterData, 
                          AlphabetData.LetterData correctLetterData)
    {
        _normalLetterData = normalLetterData;
        _selectedLetterData = selectedLetterData;
        _correctLetterData = correctLetterData;

        GetComponent<SpriteRenderer>().sprite = _normalLetterData.image;
    }

    private void OnMouseDown()
    {
        OnEnableSquareSelection();
        GameEvents.EnableSquarrSelectionMethod();
        ChechSquare();
        _displayedImage.sprite = _selectedLetterData.image;
    }

    private void OnMouseEnter()
    {
        ChechSquare();
    }

    private void OnMouseUp()
    {
        GameEvents.ClearSelectionMethod();
        GameEvents.DisableSquarrSelectionMethod();
    }

    private void ChechSquare()
    {
        if(_selected == false && _clicked == true)
        {
            _selected = true;
            GameEvents.CheckSquareMethod(_normalLetterData.letter, gameObject.transform.position, _index);
        }
    }
}
