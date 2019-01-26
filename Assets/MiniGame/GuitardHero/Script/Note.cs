using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public GameObject Image;

    public int numInput = 0;

    private void Awake()
    {
        #region Glove
        GloveInputsManager.OnFirstCombination += InputOne;
        GloveInputsManager.OnSecondCombination += InputSec;
        GloveInputsManager.OnThirdCombination += InputThird;
        GloveInputsManager.OnFourthCombination += InputFourth;
        GloveInputsManager.OnFifthCombination += InputFifth;
        #endregion
        #region XboxController
        InputsManager.OnADownInputPress += InputOne;
        InputsManager.OnBDownInputPress += InputSec;
        InputsManager.OnYDownInputPress += InputThird;
        InputsManager.OnXDownInputPress += InputFourth;
        InputsManager.OnRightBumperDownInputPress += InputFifth;
        #endregion
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
}
