using UnityEngine;
using System.Collections;

public class naoFundo : MonoBehaviour {

	private fundo 		fundo;
	public	GameObject	preto;
	public	GameObject	branco;
	public	bool 		padraoOposto; // Se padraoOposto = true entao o objeto é preto. Se padraoOposto = false entao o objeto é branco!

	// Use this for initialization
	void Start () {

		fundo = FindObjectOfType (typeof(fundo)) as fundo;

		preto.SetActive (false);
		branco.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (fundo.padrao) {
			padraoOposto = false;
		}
		else {
			padraoOposto = true;
		}

		if (padraoOposto) {
			preto.SetActive (false);
			branco.SetActive (true);
		}
		else {
			preto.SetActive (true);
			branco.SetActive (false);
		}
	
	}
}
