using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Events

    #endregion

    #region Fields / Properties
    [Header("Canvas & Achors")]
    [SerializeField] private Canvas canvas = null;
    public Canvas Canvas { get { return canvas; } }
    [SerializeField] private GameObject timerAnchor = null;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI eventTimerText = null;

    [Header("Image")]
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image timerImage = null;

    [Header("Input Field")]
    [SerializeField] private TMP_InputField solutionInputField = null;
    public TMP_InputField SolutionInputField { get { return solutionInputField; } }
    #endregion

    #region Singleton
    public static UIManager Instance = null;
    #endregion

    #region Methods

    #region Original Methods
    /// <summary>
    /// Called when entering a solution in the input field
    /// </summary>
    /// <param name="_solution"></param>
    private void EnterSolution(string _solution)
    {
        solutionInputField.text = string.Empty;
    }

    /// <summary>
    /// Called when an event ends
    /// </summary>
    public void EventEnd()
    {
        eventTimerText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Called when an event is failed
    /// </summary>
    public void EventFail()
    {
        GameObject _failFeedback = Resources.Load("fail") as GameObject;

        if (!_failFeedback) return;

        Instantiate(_failFeedback, canvas.transform, false);
        Destroy(_failFeedback, .5f);
    }

    /// <summary>
    /// Called when an event starts
    /// </summary>
    public void EventStart()
    {
        eventTimerText.text = "0";
        eventTimerText.gameObject.SetActive(true);
    }

    /// <summary>
    /// Called when an event is achieved with success
    /// </summary>
    public void EventSuccess()
    {
        GameObject _successFeedback = Resources.Load("success") as GameObject;

        if (!_successFeedback) return;

        Instantiate(_successFeedback, canvas.transform, false);
        Destroy(_successFeedback, .5f);
    }

    /// <summary>
    /// Actives the globl timer
    /// </summary>
    public void ActiveTimer()
    {
        timerAnchor.gameObject.SetActive(true);
    }

    /// <summary>
    /// Update the global timer of the game in UI
    /// </summary>
    /// <param name="_timerValue">Actual value of the timer, in percentage</param>
    public void UpdateTimer(float _timerPercent)
    {
        timerImage.fillAmount = _timerPercent;
    }

    /// <summary>
    /// Update the actual event timer in UI
    /// </summary>
    /// <param name="_eventTimer">Actual value of the event timer</param>
    /// <param name="_eventTimeLimit">Limit of the event timer ; it ends when it reach it</param>
    public void UpdateEventTimer(float _eventTimer, float _eventTimeLimit)
    {
        eventTimerText.text = ((int)(_eventTimeLimit - _eventTimer)).ToString();
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        if (!eventTimerText || !timerImage || !canvas || !solutionInputField)
        {
            Debug.Log("Missing UI reference !");
            Destroy(this);
            return;
        }

        if (!Instance) Instance = this;
        else
        {
            Destroy(this);
            return;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    // Use this for initialization
    void Start ()
    {
        if (!GameManager.Instance)
        {
            Debug.Log("No GameManager founded in the scene !");
        }
        else
        {
            GameManager.Instance.OnTimerUpdate += UpdateTimer;
            GameManager.Instance.OnEventTimerUpdate += UpdateEventTimer;
            GameManager.Instance.OnEventEnd += EventEnd;
            GameManager.Instance.OnEventFail += EventFail;
            GameManager.Instance.OnEventStart += EventStart;
            GameManager.Instance.OnEventSuccess += EventSuccess;
        }
        // Check the solution when entering it into the input field
        solutionInputField.onEndEdit.AddListener(EnterSolution);

        timerAnchor.gameObject.SetActive(false);
        eventTimerText.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    #endregion

    #endregion
}
