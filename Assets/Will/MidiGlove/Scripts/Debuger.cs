﻿using UnityEngine;

public class Debuger : MonoBehaviour
{
    [SerializeField,Header("Object Settings")]
    Renderer gameObjetToChange;
    [SerializeField]
    Transform transformToUpdate;

    void InputOne(bool _doIt)
    {
        if (!_doIt) return;
        Debug.Log("First input glove up");
        gameObjetToChange.GetComponent<Renderer>().material.color = Color.green;
    }

    void InputSec(bool _doIt)
    {
        if (!_doIt) return;
        Debug.Log("Sec input glove up");
        gameObjetToChange.GetComponent<Renderer>().material.color = Color.yellow;
    }

    void InputThird(bool _doIt)
    {
        if (!_doIt) return;
        Debug.Log("Third input glove up");
        gameObjetToChange.GetComponent<Renderer>().material.color = Color.black;
    }

    void InputFourth(bool _doIt)
    {
        if (!_doIt) return;
        Debug.Log("Fourth input glove up");
        gameObjetToChange.GetComponent<Renderer>().material.color = Color.blue;
    }

    void InputFifth(bool _doIt)
    {
        if (!_doIt) return;
        Debug.Log("Fifth input glove up");
        gameObjetToChange.GetComponent<Renderer>().material.color = Color.cyan;
    }

    void InputSix(float _value)
    {
        if (!transformToUpdate) return;
        //Debug.Log(_value);        
    }

    void InputSeven(bool _doIt)
    {
        if (!_doIt) return;
        Debug.Log("Input seven");
        gameObjetToChange.GetComponent<Renderer>().material.color = Color.magenta;
        
    }

    void InputEight(bool _doIt)
    {
        if (!_doIt) return;
        Debug.Log("Input eight");
        gameObjetToChange.GetComponent<Renderer>().material.color = Color.white;

    }

    void LeaveGame( )
    {
        Application.Quit();
    }

    private void Awake()
    {
        #region Glove
        GloveInputsManager.OnFirstCombination += InputOne;
        GloveInputsManager.OnSecondCombination += InputSec;
        GloveInputsManager.OnThirdCombination += InputThird;
        GloveInputsManager.OnFourthCombination += InputFourth;
        GloveInputsManager.OnFifthCombination += InputFifth;
        GloveInputsManager.OnSixCombination += InputSix;
        GloveInputsManager.OnSevenCombination += InputSeven;
        GloveInputsManager.OnEightCombination += InputEight;


        #endregion
        #region XboxController
        InputsManager.OnADownInputPress += InputOne;
        InputsManager.OnBDownInputPress += InputSec;
        InputsManager.OnYDownInputPress += InputThird;
        InputsManager.OnXDownInputPress += InputFourth;
        InputsManager.OnRightBumperDownInputPress += InputFifth;
        #endregion
        #region Keyboard
        InputsManager.OnKBAOneDownInputPress += InputOne;
        InputsManager.OnKBATwoDownInputPress += InputSec;
        InputsManager.OnKBAThreeDownInputPress += InputThird;
        InputsManager.OnKBAFourDownInputPress += InputFourth;
        InputsManager.OnKBAFiveInputPress += InputFifth;
        #endregion
    }

    private void Start()
    {
        if(!gameObjetToChange)
        gameObjetToChange = gameObject.GetComponent<Renderer>();
        if (!transformToUpdate)
            transformToUpdate = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) LeaveGame();

    }
}