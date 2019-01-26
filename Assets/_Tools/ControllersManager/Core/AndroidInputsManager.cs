using System;
using UnityEngine;

/*
 * Welcome into the Lord InputsManager for Android
 * Don't forget to RENAME the axes inputs for the Xbox controller in the project settings:
 * Horizontal by LeftStickX
 * Vertical by LeftStickY
 * //
 * Don't forget to SET the axes inputs for the Xbox controller in the project settings:
 * RightStickX as 3rd axis
 * RightStickY as 4th axis
 * D-PadX as 5th axis
 * D-PadY as 6th axis
 * RightTrigger as 12th axis
 * LeftTrigger  as 13th axis
 */

public class AndroidInputsManager : MonoBehaviour
{
    #region F/P
    #region Events
    #region Xbox Controller
    #region LeftStick
    public static event Action<float> OnVerticalAxisInput;
    public static event Action<float> OnHorizontalAxisInput;
    public static event Action<float, float> OnMoveAxisInput;
    #endregion
    #region RightStick
    public static event Action<float> OnRotateXAxisInput;
    public static event Action<float> OnRotateYAxisInput;
    public static event Action<float, float> OnRotateAxisInput;
    #endregion
    #region D-pad
    public static event Action<float> OnDpadxAxis;
    public static event Action<float> OnDpadyAxis;
    public static event Action<int> OnDpadxButton;
    public static event Action<int> OnDpadyButton;
    #endregion
    #region Trigger
    public static event Action<float> OnRightTriggerAxis;
    public static event Action<float> OnLeftTriggerAxis;
    #endregion
    #region  Buttons
    #region A
    //A
    public static event Action<bool> OnAInputPress;
    //AUp
    public static event Action<bool> OnAUpInputPress;
    //ADown
    public static event Action<bool> OnADownInputPress;
    #endregion
    #region B
    //B
    public static event Action<bool> OnBInputPress;
    //BUp
    public static event Action<bool> OnBUpInputPress;
    //BDown
    public static event Action<bool> OnBDownInputPress;
    #endregion
    #region X
    //X
    public static event Action<bool> OnXInputPress;
    //XUp
    public static event Action<bool> OnXUpInputPress;
    //XDown
    public static event Action<bool> OnXDownInputPress;
    #endregion
    #region Y
    //Y
    public static event Action<bool> OnYInputPress;
    //YUp
    public static event Action<bool> OnYUpInputPress;
    //YDown
    public static event Action<bool> OnYDownInputPress;
    #endregion
    #region Start
    //Start
    public static event Action<bool> OnStartInputPress;
    //StartUp
    public static event Action<bool> OnStartUpInputPress;
    //StartDown
    public static event Action<bool> OnStartDownInputPress;
    #endregion
    #region Bumper
    #region GetKeyDown
    //RightBumperDown
    public static event Action<bool> OnRightBumperDownInputPress;
    //LeftBumperDown
    public static event Action<bool> OnLeftBumperDownInputPress;
    #endregion
    #region GetKeyUp
    //RightBumperUp
    public static event Action<bool> OnRightBumperUpInputPress;
    //LeftBumperUp
    public static event Action<bool> OnLeftBumperUpInputPress;
    #endregion
    #region GetKey
    //RightBumper
    public static event Action<bool> OnRightBumperInputPress;
    //LeftBumper
    public static event Action<bool> OnLeftBumperInputPress;
    #endregion
    #endregion
    #region LeftTriggerClick
    #region GetKey
    public static event Action<bool> OnLeftStickClickInputPress;
    #endregion
    #region GetKeyDown
    public static event Action<bool> OnLeftStickClickDownInputPress;
    #endregion
    #region GetKeyUp
    public static event Action<bool> OnLeftStickClickUpInputPress;
    #endregion
    #endregion
    #region RightTriggerClick
    #region GetKey
    public static event Action<bool> OnRightStickClickInputPress;
    #endregion
    #region GetKeyDown
    public static event Action<bool> OnRightStickClickDownInputPress;
    #endregion
    #region GetKeyUp
    public static event Action<bool> OnRightStickClickUpInputPress;
    #endregion
    #endregion
    #endregion
    #endregion
    #endregion
    #region Xbox Controller
    #region Axis
    [SerializeField, Header("LeftStickX"), Range(-1, 1)]
    float leftStickX;
    public float LeftStickX { get { return leftStickX = Input.GetAxis("LeftStickX"); } }
    [SerializeField, Header("LeftStickY"), Range(-1, 1)]
    float leftStickY;
    public float LeftStickY { get { return leftStickY = Input.GetAxis("LeftStickY"); } }
    [SerializeField, Header("RightStickX"), Range(-1, 1)]
    float rightStickX;
    public float RightStickX { get { return rightStickX = Input.GetAxis("RightStickX"); } }
    [SerializeField, Header("RightStickY"), Range(-1, 1)]
    float rightStickY;
    public float RightStickY { get { return rightStickY = Input.GetAxis("RightStickY"); } }
    [SerializeField, Header("D-Pad X"), Range(-1, 1)]
    float dpadx;
    public float Dpadx { get { return dpadx = Input.GetAxis("D-PadX"); } }
    [SerializeField, Header("D-Pad X"), Range(-1, 1)]
    float dpady;
    public float Dpady { get { return dpady = Input.GetAxis("D-PadY"); } }
    [SerializeField, Header("RightTrigger"), Range(-1, 1)]
    float rightTrigger;
    public float RightTrigger { get { return rightTrigger = Input.GetAxis("RightTrigger"); } }
    [SerializeField, Header("LeftTrigger"), Range(-1, 1)]
    float leftTrigger;
    public float LeftTrigger { get { return leftTrigger = Input.GetAxis("LeftTrigger"); } }
    #endregion
    #region Buttons
    #region A
    #region GetKeyDown
    [SerializeField, Header("A Button")]
    bool aButtonDown;
    public bool AButtonDown { get { return aButtonDown = Input.GetKeyDown(KeyCode.JoystickButton0); } }
    #endregion
    #region GetKeyUp
    [SerializeField]
    bool aButtonUp;
    public bool AButtonUp { get { return aButtonUp = Input.GetKeyDown(KeyCode.JoystickButton0); } }
    #endregion
    #region GetKey
    [SerializeField]
    bool aButton;
    public bool AButton { get { return aButton = Input.GetKey(KeyCode.JoystickButton0); } }
    #endregion
    #endregion
    #region B
    #region GetKeyDown
    [SerializeField, Header("B Button")]
    bool bButtonDown;
    public bool BButtonDown { get { return bButtonDown = Input.GetKeyDown(KeyCode.JoystickButton1); } }
    #endregion
    #region GetKeyUp
    [SerializeField]
    bool bButtonUp;
    public bool BButtonUp { get { return bButtonUp = Input.GetKeyUp(KeyCode.JoystickButton1); } }
    #endregion
    #region GetKey
    [SerializeField]
    bool bButton;
    public bool BButton { get { return bButton = Input.GetKey(KeyCode.JoystickButton1); } }
    #endregion
    #endregion
    #region X
    #region GetKeyDown
    [SerializeField, Header("X Button")]
    bool xButtonDown;
    public bool XButtonDown { get { return xButtonDown = Input.GetKeyDown(KeyCode.JoystickButton2); } }
    #endregion
    #region GetKeyUp
    [SerializeField]
    bool xButtonUp;
    public bool XButtonUp { get { return xButtonUp = Input.GetKeyUp(KeyCode.JoystickButton2); } }
    #endregion
    #region GetKey
    [SerializeField]
    bool xButton;
    public bool XButton { get { return xButton = Input.GetKey(KeyCode.JoystickButton2); } }
    #endregion
    #endregion
    #region Y
    #region GetKeyDown
    [SerializeField, Header("Y Button")]
    bool yButtonDown;
    public bool YButtonDown { get { return yButtonDown = Input.GetKeyDown(KeyCode.JoystickButton3); } }
    #endregion
    #region GetKeyUp
    [SerializeField]
    bool yButtonUp;
    public bool YButtonUp { get { return yButtonUp = Input.GetKeyUp(KeyCode.JoystickButton3); } }
    #endregion
    #region GetKey
    [SerializeField]
    bool yButton;
    public bool YButton { get { return yButton = Input.GetKey(KeyCode.JoystickButton3); } }
    #endregion
    #endregion
    #region Start
    #region GetKeyDown
    [SerializeField, Header("Start Button")]
    bool startButtonDown;
    public bool StartButtonDown { get { return startButtonDown = Input.GetKeyDown(KeyCode.JoystickButton10); } }
    #endregion
    #region GetKeyUp
    [SerializeField]
    bool startButtonUp;
    public bool StartButtonUp { get { return startButtonUp = Input.GetKeyUp(KeyCode.JoystickButton10); } }
    #endregion
    #region GetKey
    [SerializeField]
    bool startButton;
    public bool StartButton { get { return startButton = Input.GetKey(KeyCode.JoystickButton10); } }
    #endregion
    #endregion
    #region Bumper
    #region GetKeyDown
    [SerializeField, Header("RightBumperDown")]
    bool rightBumperDown;
    public bool RightBumperDown { get { return rightBumperDown = Input.GetKeyDown(KeyCode.JoystickButton5); } }
    [SerializeField, Header("LeftBumperDown")]
    bool leftBumperDown;
    public bool LeftBumperDown { get { return leftBumperDown = Input.GetKeyDown(KeyCode.JoystickButton4); } }
    #endregion
    #region GetKeyUp
    [SerializeField, Header("RightBumperUp")]
    bool rightBumperUp;
    public bool RightBumperUp { get { return rightBumperUp = Input.GetKeyUp(KeyCode.JoystickButton5); } }
    [SerializeField, Header("LeftBumperUp")]
    bool leftBumperUp;
    public bool LeftBumperUp { get { return leftBumperUp = Input.GetKeyUp(KeyCode.JoystickButton4); } }
    #endregion
    #region GetKey
    [SerializeField, Header("RightBumper")]
    bool rightBumper;
    public bool RightBumper { get { return rightBumper = Input.GetKey(KeyCode.JoystickButton5); } }
    [SerializeField, Header("LeftBumper")]
    bool leftBumper;
    public bool LeftBumper { get { return leftBumper = Input.GetKey(KeyCode.JoystickButton4); } }
    #endregion
    #endregion
    #region D-pad
    [SerializeField, Header("Dpad Button")]
    static AxisToButtonTool dpadXToButton = new AxisToButtonTool();
    static AxisToButtonTool dpadYToButton = new AxisToButtonTool();
    public int DpadxButton { get { return dpadXToButton.AxisToInput("D-PadX"); } }
    public int DpadyButton { get { return dpadYToButton.AxisToInput("D-PadY"); } }
    #endregion
    #region LeftStickClick
    #region GetKeyDown
    [SerializeField, Header("leftTriggerClickDown")]
    bool leftStickClickDown;
    public bool LeftStickClickDown { get { return leftStickClickDown = Input.GetKeyDown(KeyCode.JoystickButton8); } }
    #endregion
    #region GetKeyUp
    [SerializeField, Header("leftTriggerClickUp")]
    bool leftStickClickUp;
    public bool LeftStickClickUp { get { return leftStickClickUp = Input.GetKeyUp(KeyCode.JoystickButton8); } }
    #endregion
    #region GetKey
    [SerializeField, Header("leftTriggerClick")]
    bool leftStickClick;
    public bool LeftStickClick { get { return leftStickClick = Input.GetKey(KeyCode.JoystickButton8); } }
    #endregion
    #endregion
    #region RightStickClick
    #region GetKeyDown
    [SerializeField, Header("RightTriggerClickDown")]
    bool rightStickClickDown;
    public bool RightStickClickDown { get { return rightStickClickDown = Input.GetKeyDown(KeyCode.JoystickButton9); } }
    #endregion
    #region GetKeyUp
    [SerializeField, Header("RightTriggerClickUp")]
    bool rightStickClickUp;
    public bool RightStickClickUp { get { return rightStickClickUp = Input.GetKeyUp(KeyCode.JoystickButton9); } }
    #endregion
    #region GetKey
    [SerializeField, Header("RightTriggerClick")]
    bool rightStickClick;
    public bool RightStickClick { get { return rightStickClick = Input.GetKey(KeyCode.JoystickButton9); } }
    #endregion
    #endregion
    #endregion
    #endregion
    #region otter
    public static AndroidInputsManager Instance;
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
        #region Xbox Controller
        #region LeftStick
        OnVerticalAxisInput = null;
        OnHorizontalAxisInput = null;
        OnMoveAxisInput = null;
        #endregion
        #region RightStick
        OnRotateXAxisInput = null;
        OnRotateYAxisInput = null;
        OnRotateAxisInput = null;
        #endregion
        #region D-pad
        OnDpadxAxis = null;
        OnDpadyAxis = null;
        OnDpadxButton = null;
        OnDpadyButton = null;
        #endregion
        #region Trigger
        OnRightTriggerAxis = null;
        OnLeftTriggerAxis = null;
        #endregion
        #region  Buttons
        #region A
        //A
        OnAInputPress = null;
        //AUp
        OnAUpInputPress = null;
        //ADown
        OnADownInputPress = null;
        #endregion
        #region B
        //B
        OnBInputPress = null;
        //BUp
        OnBUpInputPress = null;
        //BDown
        OnBDownInputPress = null;
        #endregion
        #region X
        //X
        OnXInputPress = null;
        //XUp
        OnXUpInputPress = null;
        //XDown
        OnXDownInputPress = null;
        #endregion
        #region Y
        //Y
        OnYInputPress = null;
        //YUp
        OnYUpInputPress = null;
        //YDown
        OnYDownInputPress = null;
        #endregion
        #region Start
        //Start
        OnStartInputPress = null;
        //StartUp
        OnStartUpInputPress = null;
        //StartDown
        OnStartDownInputPress = null;
        #endregion
        #region Bumper
        #region GetKeyDown
        //RightBumperDown
        OnRightBumperDownInputPress = null;
        //LeftBumperDown
        OnLeftBumperDownInputPress = null;
        #endregion
        #region GetKeyUp
        //RightBumperUp
        OnRightBumperUpInputPress = null;
        //LeftBumperUp
        OnLeftBumperUpInputPress = null;
        #endregion
        #region GetKey
        //RightBumper
        OnRightBumperInputPress = null;
        //LeftBumper
        OnLeftBumperInputPress = null;
        #endregion
        #endregion
        #region LeftTriggerClick
        #region GetKey
        OnLeftStickClickInputPress = null;
        #endregion
        #region GetKeyDown
        OnLeftStickClickDownInputPress = null;
        #endregion
        #region GetKeyUp
        OnLeftStickClickUpInputPress = null;
        #endregion
        #endregion
        #region RightTriggerClick
        #region GetKey
        OnRightStickClickInputPress = null;
        #endregion
        #region GetKeyDown
        OnRightStickClickDownInputPress = null;
        #endregion
        #region GetKeyUp
        OnRightStickClickUpInputPress = null;
        #endregion
        #endregion
        #endregion
        #endregion
        #endregion
        Instance = null;
    }

    void Update()
    {
        #region Xbox Controller
        #region Axis
        //LeftStick
        OnVerticalAxisInput?.Invoke(LeftStickY);
        OnHorizontalAxisInput?.Invoke(LeftStickX);
        OnMoveAxisInput?.Invoke(LeftStickX, LeftStickY);
        //RightStick
        OnRotateXAxisInput?.Invoke(RightStickX);
        OnRotateYAxisInput?.Invoke(RightStickY);
        OnRotateAxisInput?.Invoke(RightStickX, RightStickY);
        //D-Pad
        OnDpadxAxis?.Invoke(Dpadx);
        OnDpadyAxis?.Invoke(Dpady);
        //Triggers
        OnRightTriggerAxis?.Invoke(RightTrigger);
        OnLeftTriggerAxis?.Invoke(LeftTrigger);
        #endregion
        #region Buttons
        #region A
        //ADown
        OnADownInputPress?.Invoke(AButtonDown);
        //A
        OnAInputPress?.Invoke(AButton);
        //AUp
        OnAUpInputPress?.Invoke(AButtonUp);
        #endregion
        #region B
        //B
        OnBInputPress?.Invoke(BButton);
        //BUp
        OnBUpInputPress?.Invoke(BButtonUp);
        //BDown
        OnBDownInputPress?.Invoke(BButtonDown);
        #endregion
        #region X
        //X
        OnXInputPress?.Invoke(XButton);
        //BUp
        OnXUpInputPress?.Invoke(XButtonUp);
        //BDown
        OnXDownInputPress?.Invoke(XButtonDown);
        #endregion
        #region Y
        //Y
        OnYInputPress?.Invoke(YButton);
        //BUp
        OnYUpInputPress?.Invoke(YButtonUp);
        //BDown
        OnYDownInputPress?.Invoke(YButtonDown);
        #endregion
        #region Start
        //Start
        OnStartInputPress?.Invoke(StartButton);
        //StartUp
        OnStartUpInputPress?.Invoke(StartButtonUp);
        //StartDown
        OnStartDownInputPress?.Invoke(StartButtonDown);
        #endregion
        #region Bumper
        #region GetKeyDown
        OnRightBumperDownInputPress?.Invoke(RightBumperDown);
        OnLeftBumperDownInputPress?.Invoke(LeftBumperDown);
        #endregion
        #region GetKeyUp
        OnRightBumperUpInputPress?.Invoke(RightBumperUp);
        OnLeftBumperUpInputPress?.Invoke(LeftBumperUp);
        #endregion
        #region GetKey
        OnRightBumperInputPress?.Invoke(RightBumper);
        OnLeftBumperInputPress?.Invoke(LeftBumper);
        #endregion
        #endregion
        #region Dpad Button
        OnDpadxButton?.Invoke(DpadxButton);
        OnDpadyButton?.Invoke(DpadyButton);
        #endregion
        #region LeftStickClick
        #region GetKey
        OnLeftStickClickInputPress?.Invoke(LeftStickClick);
        #endregion
        #region GetKeyDown
        OnLeftStickClickDownInputPress?.Invoke(leftStickClickDown);
        #endregion
        #region GetKeyUp
        OnLeftStickClickUpInputPress?.Invoke(leftStickClickUp);
        #endregion
        #endregion
        #region RightStickClick
        #region GetKey
        OnRightStickClickInputPress?.Invoke(RightStickClick);
        #endregion
        #region GetKeyDown
        OnRightStickClickDownInputPress?.Invoke(RightStickClickDown);
        #endregion
        #region GetKeyUp
        OnRightStickClickUpInputPress?.Invoke(RightStickClickUp);
        #endregion
        #endregion

        #endregion
        #endregion
    }
    #endregion
}