using UnityEditor;
using UnityEngine;


public class GetUnknowControllerInputCaller : Editor
{
    [MenuItem("Tools/GetUnknowControllerInput/Call Get unknow input")]
    public static void CallManager()
    {
        if (FindObjectOfType<GetUnknowControllerInput>()) return;
        GameObject _manager = new GameObject("GetUnknowControllerInput", typeof(GetUnknowControllerInput));
        Selection.activeGameObject = _manager;
    }
}
