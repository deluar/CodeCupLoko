using UnityEngine;
using System.Collections;

public class movePlataforma : MonoBehaviour {

	public	float		velocidade;
	public	GameObject	objeto;
	public	Transform	A;
	public	Transform	B;
	public	Transform	destino;
	private	int 		rota;

	// Use this for initialization
	void Start () {

		rota = 0;
		objeto.transform.position = A.position;
		destino.position = B.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		float step = velocidade * Time.deltaTime;
		objeto.transform.position = Vector3.MoveTowards (objeto.transform.position, destino.position, step);

		if (objeto.transform.position == destino.position){

			StartCoroutine (espere ());

			switch (rota) {

			case 0:
				destino.position = A.position;
				rota = 1;
				break;
			case 1:
				destino.position = B.position;
				rota = 0;
				break;
			}

		}
	
	}

	IEnumerator espere(){
		float aux = velocidade;
		velocidade = 0;
		yield return new WaitForSeconds (1);
		velocidade = aux;
	}
}
