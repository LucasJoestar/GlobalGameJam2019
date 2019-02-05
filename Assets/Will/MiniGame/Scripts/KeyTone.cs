using UnityEngine;

public class KeyTone : MonoBehaviour
{
    #region F/P
    GuitardHeroGM Instance;
    #region Inputs
    [SerializeField]
    int inputValue = 0;
    [SerializeField, Range(1, 6)]
    int inputWanted = 1;
    #endregion
    #region Timer    
    bool canjusteOneTone = false;
    bool isTimerActive = false;
    bool canStartTimer = false;
    float timeIsUp;
    float toneLifeTime = 7;    
    #endregion
    #endregion

    #region Methods
    #region Check
    void CheckInputNeeded()
    {
        if (inputValue != 0 && !canjusteOneTone && isTimerActive)
        {
            if (inputWanted == inputValue)
            {
                Instance.SucessNote();
            }
            else
            {
                Instance.FailNote();
            }
            canStartTimer = false;
            inputValue = 0;
            Active(false);
        }
    }
    #endregion
    #region Inputs
    void FirstInput(bool _doIt)
    {
        if (!_doIt) return;
        inputValue = 1;
    }
    void SecondInput(bool _doIt)
    {
        if (!_doIt) return;
        inputValue = 2;
    }
    void ThirdInput(bool _doIt)
    {
        if (!_doIt) return;
        inputValue = 3;
    }
    void FourthInput(bool _doIt)
    {
        if (!_doIt) return;
        inputValue = 4;
    }
    void FifthInput(bool _doIt)
    {
        if (!_doIt) return;
        inputValue = 5;
    }
    #endregion
    public void Active(bool _isActive)
    {
        isTimerActive = _isActive;

        StartTimer();

        gameObject.SetActive(_isActive);

        inputValue = 0;

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
        if (!isTimerActive) return;
        CheckInputNeeded();
        #region Timer
        if (!canStartTimer)
        {
            canStartTimer = true;
            StartTimer();
        }
        else if (isTimerActive)
        {
            if (Time.time > timeIsUp)
            {
                Debug.Log("false 2");
                Instance.FailNote();
                inputValue = 0;
                canStartTimer = false;
                gameObject.SetActive(false);
            }
        }
        #endregion
    }
    #endregion
}