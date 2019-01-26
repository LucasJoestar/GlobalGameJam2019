using UnityEditor;
using UnityEngine;

public class ControllersManagerCaller : Editor
{
    #region AndroidInputManager
    [MenuItem("Tools/ControllersManager/Call AndroidInputManager")]
    public static void CallAndroidManager()
    {
        if (FindObjectOfType<AndroidInputsManager>()) return;
        GameObject _manager = new GameObject("AndroidInputsManager", typeof(AndroidInputsManager));
        Selection.activeGameObject = _manager;
    }
    #endregion
    #region InputManager
    [MenuItem("Tools/ControllersManager/Call InputManager")]    
    public static void CallManager()
    {
        if (FindObjectOfType<InputsManager>()) return;
        GameObject _manager = new GameObject("InputManager", typeof(InputsManager));
        Selection.activeGameObject = _manager;
    }
    #endregion   

    #region SwitchControllerManager
    [MenuItem("Tools/ControllersManager/Call Switch Controller Manager")]
    public static void CallSwitchManager()
    {
        if (!FindObjectOfType<InputsManager>() && !FindObjectOfType<SwitchControllerManager>())
        {
            GameObject _manager = new GameObject("InputManager", typeof(InputsManager));
            Selection.activeGameObject = _manager;
        }
        if (FindObjectOfType<SwitchControllerManager>()) return;
        var _inputManager = FindObjectOfType<InputsManager>();
        GameObject _switchmanager = new GameObject("SwitchControllerManager", typeof(SwitchControllerManager));
        _switchmanager.transform.parent = _inputManager.transform;
        Debug.Log("Switch controller manager added to InputManager!");
    }
    #endregion
}