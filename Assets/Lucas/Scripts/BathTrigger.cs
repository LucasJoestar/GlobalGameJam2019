using UnityEngine;

public class BathTrigger : MonoBehaviour
{
    public void EndBathRiddle()
    {
        GameManager.Instance.BathRiddleResolve();
    }
}
