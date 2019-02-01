using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Events
    /// <summary>
    /// Event called when the players have tried the found the good solution of the game
    /// </summary>
    public event Action<bool> OnSolutionCheck = null;

    /// <summary>
    /// Event called when the clues stop being displayed
    /// </summary>
    public event Action OnShowCluesEnd = null;
    #endregion

    #region Fields / Properties
    [Header("Canvas & Anchors")]
    [SerializeField] private Canvas canvas = null;
    public Canvas Canvas { get { return canvas; } }

    [SerializeField] private GameObject cluesAnchor = null;
    [SerializeField] private GameObject timerAnchor = null;

    [Header("Images")]
    [SerializeField] private Image cluesImage = null;
    [SerializeField] private Image timerImage = null;

    [Header("Int")]
    [SerializeField] private int cluesTimerLimit = 10;

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
    /// (Des)active the solution field visibility
    /// </summary>
    /// <param name="_doActive">Should this be active or not ?</param>
    public void ActiveSolutionField(bool _doActive)
    {
        solutionInputField.gameObject.SetActive(_doActive);
    }

    /// <summary>
    /// (Des)active the timer visibility
    /// </summary>
    /// <param name="_doActive">Should this be active or not ?</param>
    public void ActiveTimer(bool _doActive)
    {
        timerAnchor.SetActive(_doActive);
    }

    // Clues system
    private IEnumerator CluesSystem()
    {
        float _timer = cluesTimerLimit;
        cluesAnchor.SetActive(true);

        while (_timer > 0)
        {
            yield return new WaitForEndOfFrame();
            cluesImage.fillAmount = _timer / cluesTimerLimit;

            _timer -= Time.deltaTime;
        }

        cluesAnchor.SetActive(false);
        OnShowCluesEnd?.Invoke();
    }

    /// <summary>
    /// Called when entering a solution in the input field
    /// </summary>
    /// <param name="_solution"></param>
    private void OnEnterSolution(string _solution)
    {
        // Get if players succeeded or not
        bool _isSucceeded = _solution == GameManager.Instance.SolutionCode;

        // If it was the good solution, then triggers the end of the game
        if (_isSucceeded)
        {
            // Good feedback
            solutionInputField.gameObject.SetActive(false);
        }
        else
        {
            // Bad feedback
            solutionInputField.text = string.Empty;
        }

        // Triggers the associated event
        OnSolutionCheck?.Invoke(_isSucceeded);
    }

    // Shows movement signs clues
    public void ShowClues()
    {
        StartCoroutine(CluesSystem());
    }

    /// <summary>
    /// Updates the simon mini-game score in UI.
    /// </summary>
    /// <param name="_amount">Score used for the UI feedback.</param>
    public void UpdateSimonScore(int _score)
    {
        // ???
    }

    /// <summary>
    /// Updates the timer gauge filled amount.
    /// </summary>
    /// <param name="_percentage">New filled value of the gauge.</param>
    public void UpdateTimer(float _percentage) { timerImage.fillAmount = _percentage; }

    #region Feedback
    /// <summary>
    /// Instantiates a bad feedback.
    /// </summary>
    public void BadFeedback()
    {
        GameObject _failFeedback = Resources.Load("fail") as GameObject;

        if (!_failFeedback) return;

        GameObject _feedback = Instantiate(_failFeedback, canvas.transform, false);
        Destroy(_feedback, 1);
    }

    /// <summary>
    /// Instantiates a good feedback.
    /// </summary>
    public void GoodFeedback()
    {
        GameObject _successFeedback = Resources.Load("success") as GameObject;

        if (!_successFeedback) return;

        GameObject _feedback = Instantiate(_successFeedback, canvas.transform, false);
        Destroy(_feedback, 1);
    }
    #endregion

    #endregion

    #region Unity Methods
    private void Awake()
    {
        // Check needed componetns & destroy this if missing one
        if (!cluesAnchor || !timerAnchor || !cluesImage || !timerImage || !canvas || !solutionInputField)
        {
            Debug.Log("Missing UI reference !");
            Destroy(this);
            return;
        }

        // Set teh singleton instance of this class as this if null, or destroy self
        if (!Instance) Instance = this;
        else
        {
            Destroy(this);
            return;
        }
    }

    private void OnDestroy()
    {
        // Nullify the singleton instance if it was this.
        if (Instance == this) Instance = null;
    }

    // Use this for initialization
    void Start ()
    {
        // Check the solution when entering it into the input field
        solutionInputField.onEndEdit.AddListener(OnEnterSolution);

        timerAnchor.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    #endregion

    #endregion
}
