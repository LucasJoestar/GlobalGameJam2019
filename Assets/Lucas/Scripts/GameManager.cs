using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region Events
    public event Action<float> OnTimerUpdate = null;
    public event Action<float, float> OnEventTimerUpdate = null;

    public event Action OnEventStart = null;
    public event Action OnEventEnd = null;

    public event Action OnEventFail = null;
    public event Action OnEventSuccess = null;

    public event Action OnEventWin = null;
    public event Action OnEventLoose = null;

    public event Action<bool> OnGameEnd = null;
    #endregion

    #region Fields / Properties
    [Header("Events")]
    [SerializeField] private string[] eventNames = new string[] { };
    [SerializeField] private GuitardHeroGM currentEvent = null;

    [Header("Solution")]
    [SerializeField] private string solution = "5";

    [Header("Doors Riddle")]
    [SerializeField] private GameObject doorsRiddleAnchor = null;
    [SerializeField] private GameObject doorsRidleSign = null;
    [SerializeField] private Animator doorsRidleAnim = null;

    [Header("Bath Riddle")]
    [SerializeField] private GameObject bathRiddleAnchor = null;
    [SerializeField] private GameObject bathRiddleSign = null;
    [SerializeField] private Animator bathRiddleAnim = null;

    [Header("State")]
    [SerializeField] private bool isEventActive = false;
    [SerializeField] private bool isGameOver = false;
    [SerializeField] private bool isAtDoorsRiddle = false;
    [SerializeField] private bool isAtBathRiddle = false;
    [SerializeField] private bool isResolvingDoorsRiddle = false;
    [SerializeField] private bool isResolvingBathRiddle = false;

    [Header("Time")]
    [SerializeField] private float timer = 0;
    public float Timer
    {
        get { return timer; }
        set
        {
            value = Mathf.Clamp(value, 0, timeLimit);
            timer = value;

            UIManager.Instance?.UpdateTimer(1 - (value / timeLimit));

            if (value == 0)
            {
                EndGame(false);
            }
        }
    }
    [SerializeField] private int timeLimit = 300;
    public int TimeLimit { get { return timeLimit; } }

    [SerializeField] private float eventTimer = 0;
    public float EventTimer
    {
        get { return eventTimer; }
        set
        {
            value = Mathf.Clamp(value, 0, eventTimeLimit);
            eventTimer = value;

            UIManager.Instance?.UpdateEventTimer(value, eventTimeLimit);

            if (value == 0)
            {
                EndEvent(false);
            }
        }
    }
    [SerializeField] private float eventTimeLimit = 20;
    public float EventTimeLimit { get { return eventTimeLimit; } }

    [SerializeField] private float bathRiddleStartTime = 150;
    #endregion

    #region Singleton
    public static GameManager Instance = null;
    #endregion

    #region Methods

    #region Original Methods
    /// <summary>
    /// Checks the bath riddle
    /// </summary>
    private void BathRiddle(bool _doInput)
    {
        if (!_doInput || !isAtBathRiddle || isResolvingBathRiddle) return;

        isResolvingBathRiddle = true;

        bathRiddleSign.gameObject.SetActive(false);
        bathRiddleAnim.SetTrigger("Play");
    }

    /// <summary>
    /// Resolves the bath riddle
    /// </summary>
    public void BathRiddleResolve()
    {
        isResolvingBathRiddle = false;
        isAtBathRiddle = false;
        Destroy(bathRiddleAnchor.gameObject);
    }

    /// <summary>
    /// Starts the bath riddle
    /// </summary>
    public void BathRiddleStart()
    {
        isAtDoorsRiddle = true;
        SoundManager.Instance.PlayBathAmbiance();
    }

    /// <summary>
    /// Checks the entered solution by the players
    /// </summary>
    /// <param name="_solution"></param>
    private void CheckSolution(string _solution)
    {
        Debug.Log("Solution => " + _solution);

        if (solution == _solution)
        {
            EndGame(true);
        }
        else
        {
            Timer -= 20;
            FailEvent();
        }
    }

    /// <summary>
    /// Checks the doors riddle
    /// </summary>
    private void DoorsRiddle(bool _doInput)
    {
        if (!_doInput || !isAtDoorsRiddle || isResolvingDoorsRiddle) return;

        isResolvingDoorsRiddle = true;

        doorsRidleSign.gameObject.SetActive(false);
        doorsRidleAnim.SetTrigger("Play");

        SoundManager.Instance.PlaySuccessFeedback();
    }

    /// <summary>
    /// Resolves the doors riddle
    /// </summary>
    public void DoorsRiddleResolve()
    {
        isResolvingDoorsRiddle = false;
        isAtDoorsRiddle = false;
        Destroy(doorsRiddleAnchor.gameObject);

        SoundManager.Instance.PlayMonsterNoise();
        UIManager.Instance.ActiveTimer();
    }

    /// <summary>
    /// Make an end to an event
    /// </summary>
    /// <param name="_isSuccess"></param>
    public void EndEvent(bool _isSuccess)
    {
        isEventActive = false;

        if (_isSuccess) OnEventWin?.Invoke();
        else OnEventLoose?.Invoke();

        OnEventEnd?.Invoke();

        currentEvent.LooseEvent();
    }

    /// <summary>
    /// Clled when an event part has been failed
    /// </summary>
    private void FailEvent()
    {
        EventTimer -= 20;
        OnEventFail?.Invoke();
    }

    /// <summary>
    /// Ends the game
    /// </summary>
    /// <param name="_isSuccess"></param>
    public void EndGame(bool _isSuccess)
    {
        isGameOver = true;

        OnGameEnd?.Invoke(_isSuccess);
    }

    /// <summary>
    /// Starts a random event
    /// </summary>
    private void StartEvent()
    {
        GameObject _event = (GameObject)Resources.Load(eventNames[Random.Range(0, eventNames.Length)]);

        if (!_event)
        {
            Debug.Log("Event not found !");
            return;
        }
        currentEvent = Instantiate(_event, UIManager.Instance.Canvas.transform, false).GetComponent<GuitardHeroGM>();

        currentEvent.OnFailMiniGame += FailEvent;
        currentEvent.OnSuccessMiniGame += SuccessEvent;
        currentEvent.OnWinMiniGame += () => EndEvent(true);

        eventTimeLimit = currentEvent.gmTime;
        eventTimer = 0;
        isEventActive = true;

        OnEventStart?.Invoke();
    }

    /// <summary>
    /// Called when an event part is successfully achieved
    /// </summary>
    private void SuccessEvent()
    {
        OnEventSuccess?.Invoke();
    }

    /// <summary>
    /// Updates all timer of the game
    /// </summary>
    private void UpdateTimer()
    {
        // Update the global timer
        Timer += Time.deltaTime;

        if (timer >= timeLimit)
        {
            EndGame(false);
            return;
        }

        if (!isEventActive) return;

        // Update the event timer
        EventTimer += Time.deltaTime;

        if (eventTimer >= eventTimeLimit)
        {
            StartEvent();
        }
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        if (!Instance) Instance = this;
        else
        {
            Destroy(this);
            return;
        }

        GloveInputsManager.OnFifthCombination += DoorsRiddle;
        InputsManager.OnKBAFiveDownInputPress += DoorsRiddle;
        InputsManager.OnRightBumperDownInputPress += DoorsRiddle;

        GloveInputsManager.OnSixCombination += (float _value) => DoorsRiddle(_value > .5f);
        InputsManager.OnKBASixDownInputPress += DoorsRiddle;
        InputsManager.OnLeftBumperDownInputPress += DoorsRiddle;
    }

    private void FixedUpdate()
    {
        if (!isGameOver && !isAtDoorsRiddle) UpdateTimer();
    }

    // Use this for initialization
    void Start ()
    {
        if (!UIManager.Instance)
        {
            Debug.Log("UIManager missing !");
        }
        else
        {
            // Check the solution when entering it into the input field
            UIManager.Instance.SolutionInputField.onEndEdit.AddListener(CheckSolution);
        }
        isAtDoorsRiddle = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    #endregion

    #endregion
}
