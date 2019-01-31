using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0219
public class Note : MonoBehaviour {

    GuitardHeroGM guitardHeroGM;

    public float _noteTimeLife = 7;
    float _endTime;

    bool _timerStart = false;

    //Correspond à l'Input attendu
    [Range(1, 6)]
    public int inputWanted = 1;
    [SerializeField]
    int _inputSaisi = 0;
    bool _justeOneNote = false;

    void InputOne(bool _doIt)
    {
        if (!_doIt) return;
        int _inputSaisi = 1;
    }

    void InputSec(bool _doIt)
    {
        if (!_doIt) return;
        int _inputSaisi = 2;
    }

    void InputThird(bool _doIt)
    {
        if (!_doIt) return;
        int _inputSaisi = 3;
    }

    void InputFourth(bool _doIt)
    {
        if (!_doIt) return;
        int _inputSaisi = 4;
    }

    void InputFifth(bool _doIt)
    {
        if (!_doIt) return;
        int _inputSaisi = 5;
    }

    private void Awake()
    {
        #region Keyboard
        InputsManager.OnKBAOneDownInputPress += InputOne;
        InputsManager.OnKBATwoDownInputPress += InputSec;
        InputsManager.OnKBAThreeDownInputPress += InputThird;
        InputsManager.OnKBAFourDownInputPress += InputFourth;
        InputsManager.OnKBAFiveDownInputPress += InputFifth;
        #endregion
        #region MidiGlove
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
    void Start ()
    {
        if (!guitardHeroGM) guitardHeroGM = GuitardHeroGM.Instance;
    }
	
	// Update is called once per frame
	void Update () {
        if (_inputSaisi != 0 && !_justeOneNote) {
            //_justeOneNote = true;
            Debug.Log(name);
            Debug.Log(_inputSaisi);
            //StartCoroutine(WaitBeforeAnotherInput());
            if (inputWanted == _inputSaisi)
            {
                Debug.Log("true");
                guitardHeroGM.SucessNote();
                
            } else
            {
                Debug.Log("false");
                guitardHeroGM.FailNote();
            }
            _timerStart = false;
            _inputSaisi = 0;
            gameObject.SetActive(false);
        }

        if (!_timerStart)
        {
            _timerStart = true;
            StartTimer();
        } else
        {
            if (Time.time > _endTime)
            {
                Debug.Log("false");
                guitardHeroGM.FailNote();
                _inputSaisi = 0;
                _timerStart = false;
                gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            _inputSaisi = 1;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            _inputSaisi = 2;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            _inputSaisi = 3;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            _inputSaisi = 4;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            _inputSaisi = 5;
        }
    }

    IEnumerator WaitBeforeAnotherInput()
    {
        yield return new WaitForSeconds(0.1f);
        _justeOneNote = false;
    }

    public void StartTimer()
    {
        _endTime = Time.time + _noteTimeLife;
    }
}
