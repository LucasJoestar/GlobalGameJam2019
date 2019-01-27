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
    [Header("Canvas")]
    [SerializeField] private Canvas canvas = null;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI timerText = null;
    [SerializeField] private TextMeshProUGUI eventTimerText = null;
     
    [Header("Image")]
    [SerializeField] private Image eventTimerImage = null;

    [Header("Input Field")]
    [SerializeField] private TMP_InputField solutionInputField = null;
    public TMP_InputField SolutionInputField { get { return solutionInputField; } }
    #endregion

    #region Singleton
    public static UIManager Instance = null;
    #endregion

    #region Methods

    #region Original Methods
    // Called when an event is failed
    private void EventFail()
    {
        GameObject _failFeedback = Resources.Load("fail") as GameObject;

        if (!_failFeedback) return;

        Instantiate(_failFeedback, canvas.transform, false);
        Destroy(_failFeedback, .5f);
    }

    // Called when an event is achieved with success
    private void EventSuccess()
    {
        GameObject _successFeedback = Resources.Load("success") as GameObject;

        if (!_successFeedback) return;

        Instantiate(_successFeedback, canvas.transform, false);
        Destroy(_successFeedback, .5f);
    }

    // Update the global timer of the game in UI
    private void UpdateTimer(float _timerValue, int _timeLimit)
    {
        timerText.text = _timeLimit.ToString();
    }

    // Update the actual event timer in UI
    private void UpdateEventTimer(float _eventTimer, float _eventTimeLimit)
    {
        eventTimerText.text = _eventTimer.ToString();
        eventTimerImage.fillAmount = 1 - (_eventTimer / _eventTimeLimit);
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        if (!timerText || !eventTimerText || !eventTimerImage || !canvas || !solutionInputField)
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
            GameManager.Instance.OnEventTimerUpdae += UpdateEventTimer;
            GameManager.Instance.OnEventFail += EventFail;
            GameManager.Instance.OnEventSuccess += EventSuccess;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    #endregion

    #endregion
}
