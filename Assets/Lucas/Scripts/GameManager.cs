﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Fields / Properties
    [Header("Solution Code")]
    [SerializeField] private string solutionCode = "5";
    public string SolutionCode { get { return solutionCode ; } }

    [Header("Help Resources")]
    // Remaining chances to find the game solution
    [SerializeField] private int remainingChances = 1;
    // Remaining chances to see the glove movements clues
    [SerializeField] private int remainingCluesVisiblity = 1;

    [Header ("KeyGlyph State")]
    [SerializeField] private GameObject KeyGlyphAnchor = null;
    [SerializeField] private Animator keyGlyphAnimator = null;

    [Header("Simon")]
    // Indicates if the simon is on paused or not
    [SerializeField] private bool isSimonOnPause = false;
    // Amount of succeeded notes in a row for the simon mini-game
    [SerializeField] private int simonSuccededNotes = 0;
    // Simon mini-game combo length, the amount of combinations in a row must be succeded to win it
    [SerializeField] private int simonComboLength = 5;
    // Simon mini-game timer length
    [SerializeField] private int simonTimerLimit = 200;

    [Header("Guess What")]
    [SerializeField] private int guessWhatOneTimerLimit = 15;

    // Stored coroutines
    private Coroutine simonTimerCoroutine = null;
    private Coroutine guessWhatOneCoroutine = null;

    [Header("Events")]
    public UnityEvent OnDoorsPhaseEnd = new UnityEvent();
    public UnityEvent OnSimonPhaseEnd = new UnityEvent();
    public UnityEvent OnGuessWhatOneEnd = new UnityEvent();
    public UnityEvent OnLightOn = new UnityEvent();
    public UnityEvent OnSinkOutlet = new UnityEvent();
    #endregion

    #region Singleton
    // Singleton instance
    public static GameManager Instance = null;
    #endregion

    #region Methods

    #region Original Methods

    #region End Game
    // Ends the game. You loose, body.
    private IEnumerator GameOver()
    {
        UIManager.Instance.BadFeedback();

        yield return new WaitForSeconds(2);

        MenuManager.LoadBadEnd();
    }

    // Ends the game, and you've won, body.
    private IEnumerator WinGame()
    {
        UIManager.Instance.GoodFeedback();

        yield return new WaitForSeconds(2);

        MenuManager.LoadGoodEnd();
    }
    #endregion

    #region Game Phases
    // Manages the game phase in the bathroom
    private IEnumerator BathroomPhase()
    {
        bool _isGood = false;
        GloveInputsManager.OnSixCombination += (float _isReallyGood) => _isGood = _isReallyGood > .5f;

        while (!_isGood)
        {
            yield return null;
        }

        _isGood = false;
        GloveInputsManager.OnSixCombination -= (float _isReallyGood) => _isGood = _isReallyGood > .5f;

        OnLightOn?.Invoke();

        GloveInputsManager.OnSevenCombination += (bool _isReallyGood) => _isGood = _isReallyGood;

        while (!_isGood)
        {
            yield return null;
        }

        GloveInputsManager.OnSevenCombination -= (bool _isReallyGood) => _isGood = _isReallyGood;

        OnSinkOutlet?.Invoke();
    }

    // Manages the phase when players have to open the doors
    private IEnumerator DoorsPhase()
    {
        bool _isGood = false;
        GloveInputsManager.OnFifthCombination += (bool _isReallyGood) => _isGood = _isReallyGood;

        while (!_isGood)
        {
            yield return null;
            Debug.Log("No homo");
        }

        GloveInputsManager.OnFifthCombination -= (bool _isReallyGood) => _isGood = _isReallyGood;

        OnDoorsPhaseEnd?.Invoke();
    }

    #region Guess What
    // When players entered something to guess the solution, executes the associated things
    private void CheckSolution(bool _isSucceeded)
    {
        // If it's the good solution
        if (_isSucceeded)
        {
            UIManager.Instance.ActiveSolutionField(false);

            StartCoroutine(WinGame());
            UIManager.Instance.OnSolutionCheck -= CheckSolution;
            return;
        }
        else
        {
            remainingChances--;
            // If no more chances remains, game's over
            if (remainingChances == 0)
            {
                UIManager.Instance.ActiveSolutionField(false);

                StartCoroutine(GameOver());
                UIManager.Instance.OnSolutionCheck -= CheckSolution;
                return;
            }
            // If on guess what one phase, triggers the bath phase
            else if (guessWhatOneCoroutine != null)
            {
                OnGuessWhatOneEnd?.Invoke();
                StartCoroutine(BathroomPhase());
            }
        }

        UIManager.Instance.BadFeedback();

        // Stop coroutine if needed
        if (guessWhatOneCoroutine != null) StopCoroutine(guessWhatOneCoroutine);
    }

    // Phase when players have to guess the room where the blind guy is ; #1
    private IEnumerator GuessWhatOne()
    {
        float _gussWhatOneTimer = guessWhatOneTimerLimit;

        while (_gussWhatOneTimer > 0)
        {
            yield return null;
            _gussWhatOneTimer -= Time.deltaTime;
        }

        // Triggers event
        OnGuessWhatOneEnd?.Invoke();

        // Starts the bath phase
        StartCoroutine(BathroomPhase());
    }
    #endregion

    #region Simon
    // Ends the simon phase
    private IEnumerator EndSimon()
    {
        // Stop timer coroutine if needed
        if (simonTimerCoroutine != null) StopCoroutine(simonTimerCoroutine);
        UIManager.Instance.ActiveTimer(false);

        yield return new WaitForSeconds(2);

        // Active the guess what one phase
        guessWhatOneCoroutine = StartCoroutine(GuessWhatOne());

        // Triggers event
        OnSimonPhaseEnd?.Invoke();
    }

    // Pause the simon mini-game
    private void PauseSimon()
    {
        isSimonOnPause = true;
        UIManager.Instance.ShowClues();
    }

    // Called when failed a note in the simon mini-game
    private void SimonFailNote()
    {
        Debug.Log("What tiggle what tiggle what tiggle WHAT");

        simonSuccededNotes = 0;
        UIManager.Instance.BadFeedback();

        StartCoroutine(SimonNewNote());
    }

    // Set a new note for the simon mini-game
    private IEnumerator SimonNewNote()
    {
        UIManager.Instance.UpdateSimonScore(simonSuccededNotes);
        yield return new WaitForSeconds(2);
        GuitardHeroGM.Instance.SetNote();
    }

    // Manages the Simon mini-game timer
    private IEnumerator SimonPeggTimer()
    {
        // Creates variables
        float _timer = simonTimerLimit;

        // Set the first note of the simon
        StartCoroutine(SimonNewNote());

        // Do the simon while not succeded enough notes in a row
        while (_timer > 0)
        {
            yield return new WaitForEndOfFrame();

            if (!isSimonOnPause)
            {
                _timer -= Time.deltaTime;
                UIManager.Instance.UpdateTimer(_timer / simonTimerLimit);
            }
        }

        // This is the end... My only friend, the end
        StartCoroutine(GameOver());
    }

    // Starts the simon mini-game
    private void StartSimon()
    {
        UIManager.Instance.OnShowCluesEnd -= StartSimon;
        UIManager.Instance.OnShowCluesEnd += () => isSimonOnPause = false;

        simonTimerCoroutine = StartCoroutine(SimonPeggTimer());
    }

    // Called to invoke a new note for the simon mini-game
    private void SimonSucceedNote()
    {
        simonSuccededNotes++;
        UIManager.Instance.GoodFeedback();

        // If not enough notes succeeded in a row, set another note
        if (simonSuccededNotes < simonComboLength) StartCoroutine(SimonNewNote());
        // If note, stop the simon mini-game phase
        else
        {
            StartCoroutine(EndSimon());
        }
    }
    #endregion

    #endregion

    #endregion

    #region Unity Methods
    private void Awake()
    {
        // Set the singleton instance of this class as this or destroy self if it already exist
        if (!Instance) Instance = this;
        else
        {
            Destroy(this);
            return;
        }
    }

    private void OnDestroy()
    {
        // Nullify the singleton instance if it is this
        if (Instance == this) Instance = null;
    }

    // Use this for initialization
    void Start ()
    {
        // Set events
        UIManager.Instance.OnSolutionCheck += CheckSolution;
        UIManager.Instance.OnShowCluesEnd += StartSimon;

        // Set events for the simon mini-game
        GuitardHeroGM.Instance.OnFailMiniGame += SimonFailNote;
        GuitardHeroGM.Instance.OnSuccessMiniGame += SimonSucceedNote;

        // Starts the doors phase
        StartCoroutine(DoorsPhase());
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    #endregion

    #endregion
}
