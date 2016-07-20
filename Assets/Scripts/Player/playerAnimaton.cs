using UnityEngine;
using System.Collections;

public class playerAnimaton : MonoBehaviour {

	public	Animator	anime;
	private	player 		player;
	private	bool 		walk;
    private bool        isJumping;
    private float       velocidadeY;
    private bool        correndo;
    private bool        run;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType (typeof(player)) as player;
        velocidadeY = player.GetComponent<Rigidbody2D>().velocity.y;
        correndo = player.isRunning();
	
	}
	
	// Update is called once per frame
	void Update () {

        isJumping = player.isJumping();
        correndo = player.isRunning();

        if (player.getMovimentoX() != 0 && !correndo){
			walk = true;
            run = false;
		}
		else if(player.getMovimentoX() != 0 && correndo)
        {
			walk = false;
            run = true;
		}
        else
        {
            walk = false;
            run = false;
        }

        velocidadeY = player.GetComponent<Rigidbody2D>().velocity.y;

        

        anime.SetBool ("walk", walk);
        anime.SetBool("correndo", run);
        anime.SetBool("isJumping", isJumping);
        anime.SetFloat("velocidadeY", velocidadeY);
	
	}
}
