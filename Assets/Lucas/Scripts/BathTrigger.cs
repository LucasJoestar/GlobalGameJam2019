using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathTrigger : MonoBehaviour
{
    public void EndBathRiddle()
    {
        GameManager.Instance.BathRiddleResolve();
    }
}
