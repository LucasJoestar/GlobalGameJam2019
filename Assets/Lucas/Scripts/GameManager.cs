using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region Events
    public event Action<float, int> OnTimerUpdate = null;
    public event Action<float, float> OnEventTimerUpdae = null;

    public event Action OnEventStart = null;
    public event Action OnEventEnd = null;

    public event Action OnEventSuccess = null;
    public event Action OnEventFail = null;

    public event Action<bool> OnGameEnd = null;
    #endregion

    #region Fields / Properties
    [Header("Events")]
    [SerializeField] private string[] eventNames = new string[] { };

    [Header("Solution")]
    [SerializeField] private string solution = "5";

    [Header("State")]
    [SerializeField] private bool isEventActive = false;
    [SerializeField] private bool isGameOver = false;

    [Header("Time")]
    [SerializeField] private float timer = 0;
    public float Timer
    {
        get { return timer; }
        set
        {
            value = Mathf.Clamp(value, 0, timeLimit);
            timer = value;

            OnTimerUpdate?.Invoke(value, timeLimit);

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

            OnEventTimerUpdae?.Invoke(value, eventTimeLimit);

            if (value == 0)
            {
                EndEvent(false);
            }
        }
    }
    [SerializeField] private float eventTimeLimit = 20;
    public float EventTimeLimit { get { return eventTimeLimit; } }

    //[SerializeField] private 
    #endregion

    #region Singleton
    public static GameManager Instance = null;
    #endregion

    #region Methods

    #region Original Methods
    // Checks the entered solution by the players
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
        }
    }

    // Ends the game
    public void EndGame(bool _isSuccess)
    {
        isGameOver = true;

        OnGameEnd?.Invoke(_isSuccess);
    }

    // Make an end to an event
    public void EndEvent(bool _isSuccess)
    {
        isEventActive = false;

        OnEventEnd?.Invoke();

        if (_isSuccess) OnEventSuccess?.Invoke();
        else OnEventFail?.Invoke();
    }

    // Starts a random event
    private void StartEvent()
    {
        GameObject _event = (GameObject)Resources.Load(eventNames[Random.Range(0, eventNames.Length)]);

        if (!_event)
        {
            Debug.Log("Event not found !");
            return;
        }
        _event.transform.position = Vector3.zero;

        eventTimer = 0;
        isEventActive = true;

        OnEventStart?.Invoke();
    }

    // Updates all timer of the game
    private void UpdateTimer()
    {
        // Update the global timer
        Timer += Time.deltaTime;

        if (timer >= timeLimit)
        {
            EndGame(false);
            return;
        }

        if (isEventActive) return;

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
    }

    private void FixedUpdate()
    {
        if (!isGameOver) UpdateTimer();
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
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    #endregion

    #endregion
}
