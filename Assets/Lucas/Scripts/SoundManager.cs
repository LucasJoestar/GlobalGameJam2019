using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Events

    #endregion

    #region Fields / Properties
    [Header("Audio Source")]
    [SerializeField] private AudioSource audioSource = null;

    [Header("Music")]
    [SerializeField] private AudioClip mainTheme = null;
    [SerializeField] private AudioClip miniGameTheme = null;

    [Header("Feedbacks")]
    [SerializeField] private AudioClip failFeedback = null;
    [SerializeField] private AudioClip successFeedback = null;

    [Header("Clues")]
    [SerializeField] private AudioClip[] clues = new AudioClip[] { };

    [Header("Noise")]
    [SerializeField] private AudioClip monsterNoise = null;

    [Header("Variables")]
    [SerializeField] float mainThemeTime = 0;
    #endregion

    #region Singleton
    public static SoundManager Instance = null;
    #endregion

    #region Methods

    #region Original Methods
    // Plays a bad feedback sound
    public void PlayFailFeedback()
    {
        AudioSource.PlayClipAtPoint(failFeedback, Vector3.zero);
    }

    // Continue playing the main theme from
    public void PlayMainTheme()
    {
        audioSource.clip = mainTheme;
        audioSource.Play();
        audioSource.time = mainThemeTime;
    }

    // Plays the mini game music
    public void PlayMiniGameMusic()
    {
        mainThemeTime = audioSource.time;
        audioSource.clip = miniGameTheme;
        audioSource.Play();
    }

    // Plays the noise of the monster
    public void PlayMonsterNoise()
    {
        AudioSource.PlayClipAtPoint(monsterNoise, Vector3.zero);
    }

    // Plays a good feedback sound
    public void PlaySuccessFeedback()
    {
        AudioSource.PlayClipAtPoint(successFeedback, Vector3.zero);
    }

    // Plays a random clue
    public void PlayRandomClue()
    {
        AudioSource.PlayClipAtPoint(clues[Random.Range(0, clues.Length)], Vector3.zero);
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

    // Use this for initialization
    void Start ()
    {
		if (GameManager.Instance)
        {
            GameManager.Instance.OnEventStart += PlayMiniGameMusic;
            GameManager.Instance.OnEventEnd += PlayMainTheme;

            GameManager.Instance.OnEventSuccess += PlayRandomClue;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #endregion

    #endregion
}
