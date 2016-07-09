using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	private	player player;

	public	Transform	E;
	public	Transform	D;

	public	float		velocidadeCam;

	// Use this for initialization
	void Start () {
	
		player = FindObjectOfType (typeof(player)) as player;
	}
	
	// Update is called once per frame
	void Update () {
	
		float x = player.transform.position.x;
		Vector3 posicaoPlayer = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);

		if (x >= E.transform.position.x && x <= D.transform.position.x ){

			transform.position = Vector3.Lerp (transform.position, posicaoPlayer, velocidadeCam);
		}

		if (transform.position.x >= E.transform.position.x && transform.position.x <= D.transform.position.x){

			transform.position = Vector3.Lerp (transform.position, posicaoPlayer, velocidadeCam);
		}

	}
}
