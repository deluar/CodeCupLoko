using UnityEngine;
using System.Collections;

public class naoFundo : MonoBehaviour {

	private fundo 		fundo;
	public	GameObject	preto;
	public	GameObject	branco;
	private	bool 		padraoOposto; // Se padraoOposto = true entao o objeto é preto. Se padraoOposto = false entao o objeto é branco!

	// Use this for initialization
	void Start () {

		fundo = FindObjectOfType (typeof(fundo)) as fundo;

		preto.SetActive (false);
		branco.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		padraoOposto = !fundo.isWhite;

		preto.SetActive (!padraoOposto);
		branco.SetActive (padraoOposto);
	
	}
}
