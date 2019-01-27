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

    int _sucessRaw = 0;
    public int _winRaw = 10;

    bool _noteIsPrint = false;
    bool _waitForInput = false;

    public int gmTime = 30;

    // Use this for initialization
    void Start()
    {
        foreach(GameObject _element in _note)
        {
            _element.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate() {  
        if (!_noteIsPrint && !_waitForInput)
        {
            CheckWin();
            _note[Reroll()].SetActive(true);
            _noteIsPrint = true;
            _waitForInput = true;
            Debug.Log(_sucessRaw);
        }
    }

    public void SucessNote(){
        _sucessRaw++;
        _noteIsPrint = false;

        OnSuccessMiniGame?.Invoke();
        StartCoroutine(WaitForInput());
    }

    public void FailNote()
    {
        //_sucessRaw = 0;
        _noteIsPrint = false;
        OnFailMiniGame?.Invoke();
        StartCoroutine(WaitForInput());
    }

    public void CheckWin()
    {
        if (_sucessRaw == _winRaw)
        {
            OnWinMiniGame?.Invoke();
        }
    }

    //Chose a random next tetraminos
    private int[] m_tetraminosHistory = { 3, 4, 3, 4 };
    private int m_nextTetraminos;
    private int m_chosenTetraminos;

    public int Reroll()
    {
        m_chosenTetraminos = RollTheDice();

        for (int i = 0; i < m_tetraminosHistory.Length; i++)
        {
            if (m_chosenTetraminos == m_tetraminosHistory[i])
            {
                m_chosenTetraminos = RollTheDice();
                break;
            }
        }

        for (int i = 1; i < m_tetraminosHistory.Length; i++)
        {
            m_tetraminosHistory[i - 1] = m_tetraminosHistory[i];
        }

        m_tetraminosHistory[3] = m_chosenTetraminos;

        return m_chosenTetraminos;
    }

    private int RollTheDice()
    {
        int l_pieceChoisi = Random.Range(0, 6);

        if (l_pieceChoisi == 5)
            l_pieceChoisi = Random.Range(0, 5);

        return l_pieceChoisi;
    }

    IEnumerator WaitForInput()
    {
        yield return new WaitForSeconds(0.5f);
        _waitForInput = false;
    }
}