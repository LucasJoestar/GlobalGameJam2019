using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    GuitardHeroGM guitardHeroGM;

    //Correspond à l'Input attendu
    [Range(1, 6)]
    public int inputWanted = 1;
    [SerializeField]
    int inputSaisi = 0;

    void InputOne(bool _doIt)
    {
        if (!_doIt) return;
        inputSaisi = 1;
    }

    void InputSec(bool _doIt)
    {
        if (!_doIt) return;
        inputSaisi = 2;
    }

    void InputThird(bool _doIt)
    {
        if (!_doIt) return;
        inputSaisi = 3;
    }

    void InputFourth(bool _doIt)
    {
        if (!_doIt) return;
        inputSaisi = 4;
    }

    void InputFifth(bool _doIt)
    {
        if (!_doIt) return;
        inputSaisi = 5;
    }

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
        #region Keyboard
        InputsManager.OnKBQDownInputPress += InputOne;
        InputsManager.OnKBEDownInputPress += InputSec;
        InputsManager.OnKBADownInputPress += InputThird;
        InputsManager.OnKBXDownInputPress += InputFourth;
        InputsManager.OnKBFDownInputPress += InputFifth;
        #endregion
    }

    // Use this for initialization
    void Start ()
    {
        guitardHeroGM = GameObject.Find("GuitardHeroGM").GetComponent<GuitardHeroGM>();
    }
	
	// Update is called once per frame
	void Update () {
        if (inputSaisi != 0) {
            Debug.Log(name);
            Debug.Log(inputSaisi);
            if (inputWanted == inputSaisi)
            {
                guitardHeroGM.SucessNote();
                
            } else
            {
                guitardHeroGM.FailNote();
            }
            inputSaisi = 0;
            gameObject.SetActive(false);
        }
    }
}
