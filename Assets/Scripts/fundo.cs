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

		preto.SetActive (!padrao);
		branco.SetActive (padrao);

		if (Input.GetKeyDown (KeyCode.X)) {
			padrao = !padrao;
		}

	
	}
}
