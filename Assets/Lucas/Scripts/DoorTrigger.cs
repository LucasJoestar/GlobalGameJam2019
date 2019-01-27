using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public void EndDoorsRiddle()
    {
        GameManager.Instance.DoorsRiddleResolve();
    }
}
