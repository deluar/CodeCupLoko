using UnityEngine;
using System.Collections;

public class fundo : MonoBehaviour {

	public	GameObject	preto;
	public	GameObject	branco;
	public	bool 		padrao; // Se padrao = true entao o fundo é branco. Se padrao = false entao fundo é preto!


	// Use this for initialization
	void Start () {

//		preto.SetActive (false);
//		branco.SetActive (true);
		padrao = true;
	}
	
	// Update is called once per frame
	void Update () {
        keyboardCall();
        joystickCall();
	
	}

    void activePatterns(bool pattern){
        preto.SetActive(!pattern);
        branco.SetActive(pattern);
    }

    void keyboardCall(){
        if (Input.GetKeyDown(KeyCode.X)){
            changePattern();
            activePatterns(padrao);
        }
    }

    void joystickCall(){
        if (Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.Joystick1Button5)){
            changePattern();
            activePatterns(padrao);
        }
    }

    void changePattern(){
        padrao = !padrao;
    }
}
