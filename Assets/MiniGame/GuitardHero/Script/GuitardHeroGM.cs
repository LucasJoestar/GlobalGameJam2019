using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GuitardHeroGM : MonoBehaviour
{

    public event Action OnFailMiniGame = null;
    public event Action OnSuccessMiniGame = null;

    public GameObject[] _note;

<<<<<<< Updated upstream
    public int gmTime = 30;

    public static GuitardHeroGM Instance = null;


<<<<<<< Updated upstream
=======
    public int gmTime = 7;

    public static GuitardHeroGM Instance = null;

>>>>>>> Stashed changes
    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }
<<<<<<< Updated upstream
=======
    public static GuitardHeroGM Instance = null;

    private void Awake()
    {
        if (!Instance) Instance = this;
    }

>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    // Use this for initialization
    void Start()
    {
        foreach(GameObject _element in _note)
        {
            _element.SetActive(false);
        }
<<<<<<< Updated upstream
=======
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
    public void CheckWin()
    {

    }

    public int Reroll()
    {
        int l_pieceChoisi = Random.Range(0, 6);
=======
    public int Reroll()
    {
        int l_pieceChoisi = Random.Range(0,5);
>>>>>>> Stashed changes

        if (l_pieceChoisi == 4)
            l_pieceChoisi = Random.Range(0, 4);

        return l_pieceChoisi;
    }

    public void SetNote()
    {
        _note[Reroll()].SetActive(true);
    }
}