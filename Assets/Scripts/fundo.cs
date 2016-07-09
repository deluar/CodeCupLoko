using UnityEngine;
using System.Collections;

public class fundo : MonoBehaviour {

	public	GameObject	preto;
	public	GameObject	branco;
	public	bool 		padrao; // Se padrao = true entao o fundo é branco. Se padrao = false entao fundo é preto!


	// Use this for initialization
	void Start () {

		preto.SetActive (false);
		branco.SetActive (true);
		padrao = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!padrao) {
			preto.SetActive (true);
			branco.SetActive (false);
		} 
		else {
			preto.SetActive (false);
			branco.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			padrao = !padrao;
		}

	
	}
}
