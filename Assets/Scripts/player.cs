using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public	Rigidbody2D	rbPlayer;
	public	float 		speed;
	public	float 		movimentoX;

	public	bool 		facingRight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		movimentoX = Input.GetAxisRaw ("Horizontal");
		rbPlayer.velocity = new Vector2 (movimentoX * speed, rbPlayer.velocity.y);

		if (movimentoX > 0 && !facingRight) {
			Flip ();
		} else if(movimentoX < 0 && facingRight){
			Flip ();
		}

	}

	void Flip(){

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	/*
	void OnCollisionEnter2D(Collision2D col){

		switch (col.gameObject.tag){

		case "Plataforma":
			transform.parent = col.gameObject.transform;
			Debug.Log ("Dentro");
			break;
		}
	}

	void OnCollisionExit2D(Collision2D col){

		switch (col.gameObject.tag){

		case "Plataforma":
			transform.parent = null;
			Debug.Log ("Fora");
			break;
		}
	}
	*/
}
