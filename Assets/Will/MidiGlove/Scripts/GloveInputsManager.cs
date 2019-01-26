using System;
using UnityEngine;
using MidiJack;

public class GloveInputsManager : MonoBehaviour
{
    #region F/P
    #region Events
    #region Glove Controller    
    #region FingersCombinaison
    public static event Action<bool> OnFirstCombination;
    public static event Action<bool> OnSecondCombination;
    public static event Action<bool> OnThirdCombination;
    public static event Action<bool> OnFourthCombination;
    #endregion
    #endregion
    #endregion
    #region Glove Controller
    #region FingersCombination
    #region FirstCombination
    #region GetKeyDown
    [SerializeField, Header("FirstCombination")]
    bool firstCombination;
    public bool FirstCombination { get { return firstCombination = MidiMaster.GetKeyDown(MidiChannel.Ch1, 0); } }
    #endregion
    //#region GetKeyUp
    //[SerializeField]
    //bool aButtonUp;
    //public bool AButtonUp { get { return aButtonUp = Input.GetKeyDown(KeyCode.JoystickButton0); } }
    //#endregion
    //#region GetKey
    //[SerializeField]
    //bool aButton;
    //public bool AButton { get { return aButton = Input.GetKey(KeyCode.JoystickButton0); } }
    //#endregion
    #endregion
    #region SecondCombination
    #region GetKeyDown
    [SerializeField, Header("SecondCombination")]
    bool secondCombination;
    public bool SecondCombination { get { return secondCombination = MidiMaster.GetKeyDown(MidiChannel.Ch1, 2); } }
    #endregion
    //#region GetKeyUp
    //[SerializeField]
    //bool bButtonUp;
    //public bool BButtonUp { get { return bButtonUp = Input.GetKeyUp(KeyCode.JoystickButton1); } }
    //#endregion
    //#region GetKey
    //[SerializeField]
    //bool bButton;
    //public bool BButton { get { return bButton = Input.GetKey(KeyCode.JoystickButton1); } }
    //#endregion
    #endregion
    #region ThirdCombination
    #region GetKeyDown
    [SerializeField, Header("ThirdCombination")]
    bool thirdCombination;
    public bool ThirdCombination { get { return thirdCombination = MidiMaster.GetKeyDown(MidiChannel.Ch1, 4); } }
    #endregion
    //#region GetKeyUp
    //[SerializeField]
    //bool xButtonUp;
    //public bool XButtonUp { get { return xButtonUp = Input.GetKeyUp(KeyCode.JoystickButton2); } }
    //#endregion
    //#region GetKey
    //[SerializeField]
    //bool xButton;
    //public bool XButton { get { return xButton = Input.GetKey(KeyCode.JoystickButton2); } }
    //#endregion
    #endregion
    #region FourthCombination
    #region GetKeyDown
    [SerializeField, Header("FourthCombination")]
    bool fourthCombination;
    public bool FourthCombination { get { return fourthCombination = MidiMaster.GetKeyDown(MidiChannel.Ch1, 9); } }
    #endregion
    //#region GetKeyUp
    //[SerializeField]
    //bool yButtonUp;
    //public bool YButtonUp { get { return yButtonUp = Input.GetKeyUp(KeyCode.JoystickButton3); } }
    //#endregion
    //#region GetKey
    //[SerializeField]
    //bool yButton;
    //public bool YButton { get { return yButton = Input.GetKey(KeyCode.JoystickButton3); } }
    //#endregion
    #endregion
    #endregion
    #endregion
    #region otter
    public static GloveInputsManager Instance;
    #endregion
    #endregion

    #region Meths
    void TestAxis(float _x, float _y)
    {
        //move
    }
    #endregion

    #region UniMeths
    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Already an Input Manager in the Scene !");
            Destroy(this);
        }
    }

    void OnDestroy()
    {
        #region Events        
        #region FingersCombinaison
        OnFirstCombination = null;
        OnSecondCombination = null;
        OnThirdCombination = null;
        OnFourthCombination = null;
        #endregion        
        #endregion
        Instance = null;
    }

    void Update()
    {
        #region Glove Controller        
        #region FingersCombinaison
        #region FirstCombination
        OnFirstCombination?.Invoke(FirstCombination);
        #endregion
        #region SecondCombination
        OnSecondCombination?.Invoke(SecondCombination);
        #endregion
        #region ThirdCombination
        OnThirdCombination?.Invoke(ThirdCombination);
        #endregion
        #region FourthCombination
        OnFourthCombination?.Invoke(FourthCombination);
        #endregion
        #endregion
        #endregion
    }
    #endregion

}