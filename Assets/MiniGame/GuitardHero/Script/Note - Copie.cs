using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Old : MonoBehaviour {

    GuitardHeroGM guitardHeroGM;

    //Correspond à l'Input attendu
    [Range(1, 6)]
    public int inputWanted = 1;
    [SerializeField]
    int _inputSaisi = 0;
    bool _justeOneNote = false;

    // Use this for initialization
    void Start ()
    {
        guitardHeroGM = GameObject.Find("GuitardHeroGM").GetComponent<GuitardHeroGM>();
    }
	
	// Update is called once per frame
	void Update () {
        if (_inputSaisi != 0 && !_justeOneNote) {
            _justeOneNote = true;
            Debug.Log(name);
            Debug.Log(_inputSaisi);
            StartCoroutine(WaitBeforeAnotherInput());
            if (inputWanted == _inputSaisi)
            {
                Debug.Log("true");
                guitardHeroGM.SucessNote();
                
            } else
            {
                Debug.Log("false");
                guitardHeroGM.FailNote();
            }
            _inputSaisi = 0;
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            _inputSaisi = 1;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            _inputSaisi = 2;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            _inputSaisi = 3;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            _inputSaisi = 4;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            _inputSaisi = 5;
        }
    }

    IEnumerator WaitBeforeAnotherInput()
    {
        yield return new WaitForSeconds(0.1f);
        _justeOneNote = false;
    }
}
