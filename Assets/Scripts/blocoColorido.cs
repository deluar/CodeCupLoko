using UnityEngine;
using System.Collections;

public class blocoColorido : MonoBehaviour {

	public	string	nomeFase;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.tag == "Personagem"){
			Application.LoadLevel (nomeFase);
		}
	}
}
