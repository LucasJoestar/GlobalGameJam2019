using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GuitardHeroGM : MonoBehaviour
{

    public event Action OnFailMiniGame = null;
    public event Action OnSuccessMiniGame = null;

    public KeyTone[] _note;
    KeyTone lastActivated = null;


    public int gmTime = 30;

    public static GuitardHeroGM Instance = null;


    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }


    // Use this for initialization
    void Start()
    {
        foreach(KeyTone _element in _note)
        {
            _element.Active(false);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    public void SucessNote(){
        OnSuccessMiniGame?.Invoke();
        //StartCoroutine(WaitForInput());
    }

    public void FailNote()
    {
        OnFailMiniGame?.Invoke();
       // StartCoroutine(WaitForInput());
    }

    public void LooseEvent()
    {
        Destroy(gameObject);
    }

    public void CheckWin()
    {

    }


    public int Reroll()
    {
        int l_pieceChoisi = Random.Range(0,5);

        if (l_pieceChoisi == 4)
            l_pieceChoisi = Random.Range(0, 4);

        return l_pieceChoisi;
    }

    public int SetNote()
    {
        int _id = Reroll();
        lastActivated = _note[_id];
        lastActivated.Active(true);

        return _id;
    }

    public void Pause(bool _doPause)
    {
        if (lastActivated) lastActivated.Active(!lastActivated);
    }
}
