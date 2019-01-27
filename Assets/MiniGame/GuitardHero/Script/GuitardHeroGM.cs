using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitardHeroGM : MonoBehaviour {


    public GameObject[] _note;

    int _sucessRaw = 0;

    bool _noteIsPrint = false;

    // Use this for initialization
    void Start() {
        foreach(GameObject _element in _note)
        {
            _element.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {
        
        if (!_noteIsPrint)
        {
            _note[Reroll()].SetActive(true);
            _noteIsPrint = true;
            Debug.Log(_sucessRaw);
        }
    }

    public void SucessNote(){
        _sucessRaw++;
        _noteIsPrint = false;
        
    }

    public void FailNote()
    {
        _sucessRaw = 0;
        _noteIsPrint = false;
    }

    //Chose a random next tetraminos
    private int[] m_tetraminosHistory = { 3, 4, 4, 3 };
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
}