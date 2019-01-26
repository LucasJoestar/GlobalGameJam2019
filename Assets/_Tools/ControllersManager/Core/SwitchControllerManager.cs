using System;
using UnityEngine;

public class SwitchControllerManager : MonoBehaviour
{
    #region F/P   
    #region Keyboard
    //Kb alphanumerique
    [SerializeField, Header("keyboard alphanumerique")]
    bool kbAlphanumeriqueCanMakeSwitch = true;
    //Kb directional arrow
    [SerializeField, Header("keyboard directional arrow")]
    bool kbDirectionalArrowCanMakeSwitch = true;
    //Kb keypad
    [SerializeField, Header("keyboard keypad")]
    bool kbKeypadCanMakeSwitch = true;
    //Kb letres
    [SerializeField, Header("keyboard letres")]
    bool kbLetresCanMakeSwitch = true;
    //Kb Special keys
    [SerializeField, Header("keyboard Special keys")]
    bool kbSpecialKeysCanMakeSwitch = true;
    #endregion
    #region Mouse
    [SerializeField,Header("Mouse Axis")]
    bool mouseAxisCanMakeSwitch = true;
    [SerializeField, Header("Mouse Buttons")]
    bool mouseButtonsCanMakeSwitch = true;
    #endregion
    #region Xbox Controller
    [SerializeField, Header("Xbox Controller Axis")]
    bool xboxControllerAxisCanMakeSwitch = true;
    [SerializeField, Header("Xbox Controller Buttons")]
    bool xboxControllerButtonsCanMakeSwitch = true;
    #endregion
    #endregion

    #region Meths
    #region Switch hide N show cursor
    #region Hide
    void CursorHide(bool _test)
    {
        if (_test == true && Cursor.visible == true)
        {
            Cursor.visible = false;
            Debug.Log("Disable");
        }
    }

    void CursorHide(float _test)
    {
        if (_test > .19f && Cursor.visible == true)
        {
            Cursor.visible = false;
            Debug.Log("Disable");
        }
    }

    void CursorHide(float _test, float _testSec)
    {
        if (_test >.19f && _testSec >.19f && Cursor.visible == true)
        {
            Cursor.visible = false;
            Debug.Log("Disable");
        }
    }
    #endregion
    #region Show
    void CursorShow(bool _test)
    {
        if (_test == true && Cursor.visible == false)
        {
            Cursor.visible = true;
            Debug.Log("Enable");
        }
    }

    void CursorShow(float _test, float _testSec)
    {
        if (_test > .19f && _testSec > .19f && Cursor.visible == false)
        {
            Cursor.visible = true;
            Debug.Log("Enable");
        }
    }
    #endregion
    #endregion

    #region Input detected
    void XboxController()
    {
        if(xboxControllerAxisCanMakeSwitch)
        {
            InputsManager.OnMoveAxisInput += CursorHide;
            InputsManager.OnRotateAxisInput += CursorHide;
        }
        if (xboxControllerButtonsCanMakeSwitch)
        {
            InputsManager.OnADownInputPress += CursorHide;
            InputsManager.OnBDownInputPress += CursorHide;
            InputsManager.OnYDownInputPress += CursorHide;
            InputsManager.OnXDownInputPress += CursorHide;
            InputsManager.OnStartDownInputPress += CursorHide;
            InputsManager.OnBackDownInputPress += CursorHide;
        }
    }

    void KeyboardMouseController()
    {
        //mouse
        if(mouseAxisCanMakeSwitch)
        {
            InputsManager.OnMoveMouseAxisInput += CursorShow;
        }
        if (mouseButtonsCanMakeSwitch)
        {
            InputsManager.OnLeftClickDownInputPress += CursorShow;
            InputsManager.OnRightClickDownInputPress += CursorShow;
            InputsManager.OnWheelClickDownInputPress += CursorShow;
        }
        //Kb alphanumerique
        if (kbAlphanumeriqueCanMakeSwitch)
        {
            InputsManager.OnKBAOneDownInputPress += CursorShow;
            InputsManager.OnKBATwoDownInputPress += CursorShow;
            InputsManager.OnKBAThreeDownInputPress += CursorShow;
            InputsManager.OnKBAFourDownInputPress += CursorShow;
            InputsManager.OnKBAFiveDownInputPress += CursorShow;
            InputsManager.OnKBASixDownInputPress += CursorShow;
            InputsManager.OnKBASevenDownInputPress += CursorShow;
            InputsManager.OnKBAEightDownInputPress += CursorShow;
            InputsManager.OnKBANineDownInputPress += CursorShow;
            InputsManager.OnKBAZeroDownInputPress += CursorShow;
        }
        //Kb directional arrow
        if (kbDirectionalArrowCanMakeSwitch)
        {
            InputsManager.OnLeftArrowDownInputPress += CursorShow;
            InputsManager.OnRightArrowDownInputPress += CursorShow;
            InputsManager.OnUpArrowDownInputPress += CursorShow;
            InputsManager.OnDownArrowDownInputPress += CursorShow;
        }
        //Kb keypad
        if (kbKeypadCanMakeSwitch)
        {
            InputsManager.OnKPAOneDownInputPress += CursorShow;
            InputsManager.OnKPATwoDownInputPress += CursorShow;
            InputsManager.OnKPAThreeDownInputPress += CursorShow;
            InputsManager.OnKPAFourDownInputPress += CursorShow;
            InputsManager.OnKPAFiveDownInputPress += CursorShow;
            InputsManager.OnKPASixDownInputPress += CursorShow;
            InputsManager.OnKPASevenDownInputPress += CursorShow;
            InputsManager.OnKPAEightDownInputPress += CursorShow;
            InputsManager.OnKPANineDownInputPress += CursorShow;
            InputsManager.OnKPAZeroDownInputPress += CursorShow;
        }
        //kb letres
        if (kbLetresCanMakeSwitch)
        {
            InputsManager.OnKBADownInputPress += CursorShow;
            InputsManager.OnKBZDownInputPress += CursorShow;
            InputsManager.OnKBEDownInputPress += CursorShow;
            InputsManager.OnKBRDownInputPress += CursorShow;
            InputsManager.OnKBTDownInputPress += CursorShow;
            InputsManager.OnKBYDownInputPress += CursorShow;
            InputsManager.OnKBUDownInputPress += CursorShow;
            InputsManager.OnKBIDownInputPress += CursorShow;
            InputsManager.OnKBODownInputPress += CursorShow;
            InputsManager.OnKBPDownInputPress += CursorShow;
            InputsManager.OnKBQDownInputPress += CursorShow;
            InputsManager.OnKBSDownInputPress += CursorShow;
            InputsManager.OnKBDDownInputPress += CursorShow;
            InputsManager.OnKBFDownInputPress += CursorShow;
            InputsManager.OnKBGDownInputPress += CursorShow;
            InputsManager.OnKBHDownInputPress += CursorShow;
            InputsManager.OnKBJDownInputPress += CursorShow;
            InputsManager.OnKBKDownInputPress += CursorShow;
            InputsManager.OnKBLDownInputPress += CursorShow;
            InputsManager.OnKBMDownInputPress += CursorShow;
            InputsManager.OnKBWDownInputPress += CursorShow;
            InputsManager.OnKBXDownInputPress += CursorShow;
            InputsManager.OnKBCDownInputPress += CursorShow;
            InputsManager.OnKBVDownInputPress += CursorShow;
            InputsManager.OnKBBDownInputPress += CursorShow;
            InputsManager.OnKBNDownInputPress += CursorShow;
        }
        //Kb Special keys
        if (kbSpecialKeysCanMakeSwitch)
        {
            InputsManager.OnEscapeClickDownInputPress += CursorShow;
        }
    }
    #endregion
    #endregion

    #region UniMeth
    private void Awake()
    {
        KeyboardMouseController();
        XboxController();
    }
    #endregion
}