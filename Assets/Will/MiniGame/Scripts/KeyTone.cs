using UnityEngine;

public class KeyTone : MonoBehaviour
{
    #region F/P
    GuitardHeroGM Instance;
    [SerializeField]
    int inputValue = 0;
    [SerializeField]
    float toneLifeTime = 7;
    float timeIsUp;
    bool timerStart = false;
    [SerializeField,Range(1,6)]
    int inputWanted = 1;
    bool justeOneTone = false;
    bool isTimerActive = false;
    #endregion

    #region Methods
    #region Check
    void CheckInputNeeded()
    {
        if (inputValue != 0 && !justeOneTone)
        {
            //Debug.Log(name);
            //Debug.Log(inputValue);
            if (inputWanted == inputValue)
            {
                //Debug.Log("true");
                Instance.SucessNote();
            }
            else
            {
                //Debug.Log("false");
                Instance.FailNote();
            }
            timerStart = false;
            inputValue = 0;
            Active(false);
        }
    }
    #endregion
    #region Inputs
    void FirstInput(bool _doIt)
    {
        if (!_doIt) return;
        //Debug.Log("Input 1");
        inputValue = 1;
    }
    void SecondInput(bool _doIt)
    {
        if (!_doIt) return;
        //Debug.Log("Input 2");
        inputValue = 2;
    }
    void ThirdInput(bool _doIt)
    {
        if (!_doIt) return;
        //Debug.Log("Input 3");
        inputValue = 3;
    }
    void FourthInput(bool _doIt)
    {
        if (!_doIt) return;
        //Debug.Log("Input 4");
        inputValue = 4;
    }
    void FifthInput(bool _doIt)
    {
        if (!_doIt) return;
        //Debug.Log("Input 5");
        inputValue = 5;
    }
    #endregion
    public void Active(bool _doActive)
    {
        gameObject.SetActive(_doActive);
        isTimerActive = _doActive;
    }
    public void StartTimer()
    {
        timeIsUp = Time.time + toneLifeTime;
    }
    #endregion

    #region UnityMethods
    private void Awake()
    {
        #region Keyboard
        InputsManager.OnKBAOneDownInputPress += FirstInput;
        InputsManager.OnKBATwoDownInputPress += SecondInput;
        InputsManager.OnKBAThreeDownInputPress += ThirdInput;
        InputsManager.OnKBAFourDownInputPress += FourthInput;
        InputsManager.OnKBAFiveDownInputPress += FifthInput;
        #endregion
        #region MidiGlove
        GloveInputsManager.OnFirstCombination += FirstInput;
        GloveInputsManager.OnSecondCombination += SecondInput;
        GloveInputsManager.OnThirdCombination += ThirdInput;
        GloveInputsManager.OnFourthCombination += FourthInput;
        GloveInputsManager.OnFifthCombination += FifthInput;
        #endregion
        #region XboxController
        InputsManager.OnADownInputPress += FirstInput;
        InputsManager.OnBDownInputPress += SecondInput;
        InputsManager.OnYDownInputPress += ThirdInput;
        InputsManager.OnXDownInputPress += FourthInput;
        InputsManager.OnRightBumperDownInputPress += FifthInput;
        #endregion
    }
    private void Start()
    {
        if (!Instance) Instance = GuitardHeroGM.Instance;
    }
    private void Update()
    {
        CheckInputNeeded();
        //Timer
        if (!timerStart)
        {
            timerStart = true;
            StartTimer();
        }
        else if (isTimerActive)
        {
            if (Time.time > timeIsUp)
            {
                //Debug.Log("false");
                Instance.FailNote();
                inputValue = 0;
                timerStart = false;
                gameObject.SetActive(false);
            }
        }
    }
    #endregion
}
