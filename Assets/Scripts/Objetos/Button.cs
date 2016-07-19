using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public bool isPressed;
    private bool isPressedByPlayer;
    private bool isPressedByBox;

	// Use this for initialization
	void Start () {
        isPressedByPlayer = false;
        isPressedByBox = false;
        isPressed = false;
	}
	
	// Update is called once per frame
	void Update () {
        isPressed = (isPressedByPlayer || isPressedByBox);
	}

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Personagem")
            isPressedByPlayer = true;

        if (col.gameObject.tag == "Caixa")
            isPressedByBox = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Personagem")
            isPressedByPlayer = false;

        if (col.gameObject.tag == "Caixa")
            isPressedByBox = false;
    }
}
