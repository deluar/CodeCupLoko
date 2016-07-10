using UnityEngine;
using System.Collections;

public class playerAnimaton : MonoBehaviour {

	public	Animator	anime;
	private	player 		player;
	private	bool 		walk;
    private bool        isJumping;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType (typeof(player)) as player;
	
	}
	
	// Update is called once per frame
	void Update () {

        isJumping = player.isJumping;

		if(player.movimentoX != 0){
			walk = true;
		}
		else{
			walk = false;
		}

		anime.SetBool ("walk", walk);
        anime.SetBool("isJumping", isJumping);
	
	}
}
