using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GuitardHeroGM : MonoBehaviour {

    public event Action OnFailMiniGame = null;
    public event Action OnSuccessMiniGame = null;
    public event Action OnWinMiniGame = null;

    public GameObject[] _note;

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
        foreach(GameObject _element in _note)
        {
            _element.SetActive(false);
        }
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
        int l_pieceChoisi = Random.Range(0, 6);

        if (l_pieceChoisi == 5)
            l_pieceChoisi = Random.Range(0, 5);

        return l_pieceChoisi;
    }

    public void SetNote()
    {
        _note[Reroll()].SetActive(true);
    }
}