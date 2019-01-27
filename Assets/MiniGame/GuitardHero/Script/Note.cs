using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    GuitardHeroGM _guitardHeroGM;

    //Correspond à l'Input attendu
    [Range(1, 6)]
    public int _inputWanted = 1;
    [SerializeField]
    int _inputSaisi = 0;

    public float _timeToPlayNote;
    float _endOfTime;
    bool _timerAsStart = false;

    void InputOne(bool _doIt)
    {
        if (!_doIt) return;
        _inputSaisi = 1;
    }

    void InputSec(bool _doIt)
    {
        if (!_doIt) return;
        _inputSaisi = 2;
    }

    void InputThird(bool _doIt)
    {
        if (!_doIt) return;
        _inputSaisi = 3;
    }

    void InputFourth(bool _doIt)
    {
        if (!_doIt) return;
        _inputSaisi = 4;
    }

    void InputFifth(bool _doIt)
    {
        if (!_doIt) return;
        _inputSaisi = 5;
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
        _guitardHeroGM = GameObject.Find("GuitardHeroGM").GetComponent<GuitardHeroGM>();
    }
	
	// Update is called once per frame
	void Update () {
        if (_inputSaisi != 0) {
            Debug.Log(name);
            Debug.Log(_inputSaisi);
            if (_inputWanted == _inputSaisi)
            {
                _guitardHeroGM.SucessNote();
                
            } else
            {
                _guitardHeroGM.FailNote();
            }
            _inputSaisi = 0;
            gameObject.SetActive(false);
        }

        /*if (!_timerAsStart)
        {
            StartTimer();
            _timerAsStart = true;
        } else
        {
            if(Time.time > _endOfTime)
            {
                _timerAsStart = false;
                _inputSaisi = 0;
                _guitardHeroGM.FailNote();
                gameObject.SetActive(false);
            }
        }

        /*if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            _inputSaisi = 1;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            _inputSaisi = 2;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            _inputSaisi = 4;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            _inputSaisi = 3;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            _inputSaisi = 5;
        }*/
    }

    void StartTimer()
    {
        _endOfTime = Time.time + _timeToPlayNote;
    }
}
