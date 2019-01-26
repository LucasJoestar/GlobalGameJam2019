using UnityEngine;

public class Debuger : MonoBehaviour
{
    [SerializeField,Header("Object Settings")]
    Renderer gameObjetToChange;

    
    void InputOne(bool _doIt)
    {
        if (!_doIt) return;
        Debug.Log("First input glove up");
        gameObjetToChange.GetComponent<Renderer>().material.color = Color.green;
    }

    void InputSec(bool _doIt)
    {
        if (!_doIt) return;
        Debug.Log("Sec input glove up");
        gameObjetToChange.GetComponent<Renderer>().material.color = Color.yellow;
    }

    void InputThird(bool _doIt)
    {
        if (!_doIt) return;
        Debug.Log("Third input glove up");
        gameObjetToChange.GetComponent<Renderer>().material.color = Color.black;
    }

    void InputFourth(bool _doIt)
    {
        if (!_doIt) return;
        Debug.Log("Fourth input glove up");
        gameObjetToChange.GetComponent<Renderer>().material.color = Color.blue;
    }

    void LeaveGame( )
    {
        Application.Quit();
    }

    private void Awake()
    {
        #region Glove
        GloveInputsManager.OnFirstCombination += InputOne;
        GloveInputsManager.OnSecondCombination += InputSec;
        GloveInputsManager.OnThirdCombination += InputThird;
        GloveInputsManager.OnFourthCombination += InputFourth;
        #endregion
        #region XboxController
        InputsManager.OnADownInputPress += InputOne;
        InputsManager.OnBDownInputPress += InputSec;
        InputsManager.OnYDownInputPress += InputThird;
        InputsManager.OnXDownInputPress += InputFourth;
        #endregion
    }

    private void Start()
    {
        if(!gameObjetToChange)
        gameObjetToChange = gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) LeaveGame();

    }
}