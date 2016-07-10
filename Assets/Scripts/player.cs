using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public	Rigidbody2D	rbPlayer;
	public	float 		speed;
    public  float       speedRunning;
	public	float 		movimentoX;

    public  bool        isJumping;
    public  int         jumpForce;
    public  bool        isGrounded;
    public bool collideWithWallOnRightSide;

    public bool         parede;

	public	bool 		facingRight;

	// Use this for initialization
	void Start () {
        isJumping = false;
        jumpForce = 20;
        
        speed = 6;
        speedRunning = 10;

        collideWithWallOnRightSide = false;
    }
	
	// Update is called once per frame
	void Update () {
        keyBoardCalls();

    }

    void keyBoardCalls()
    {
        movimentoX = Input.GetAxisRaw("Horizontal");

        //se ele tiver controlando pelo W, A, S, D
        if(movimentoX == 0){
            if (Input.GetKey(KeyCode.A))
                movimentoX = -1;
            else if (Input.GetKey(KeyCode.D))
                movimentoX = 1;
        }

        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetKey(KeyCode.Z))){
            if(!parede){
                rbPlayer.velocity = new Vector2(movimentoX * speedRunning, rbPlayer.velocity.y);
            }
        }
        else{
            if (!parede) {
                rbPlayer.velocity = new Vector2(movimentoX * speed, rbPlayer.velocity.y);
            }   
        }
            


        if (movimentoX > 0 && !facingRight){
            Flip();
        }
        else if (movimentoX < 0 && facingRight){
            Flip();
        }

        if ((Input.GetKey(KeyCode.Space) || (Input.GetAxisRaw("Vertical") > 0)) && !isJumping && isGrounded)
            jump();

        if ((collideWithWallOnRightSide && !facingRight) || (!collideWithWallOnRightSide && facingRight))
            parede = false;
    }

	void Flip(){
        gameObject.transform.Rotate(new Vector3(0, 180, 0));
		facingRight = !facingRight;
	}

    void jump() {
        rbPlayer.velocity = new Vector2(0, jumpForce);
        isJumping = true;
    }

    void OnTriggerEnter2D(Collider2D col){
        print("1");
        if (col.gameObject.tag == "Ground"){
            isJumping = false;
            print("2");
        }

        if(!col.isTrigger && col.gameObject.tag == "Parede"){
            parede = true;
        }
    }

    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Ground"){
            isGrounded = true;
            collideWithWallOnRightSide = facingRight;
        }

        if (!col.isTrigger && col.gameObject.tag == "Parede")
        {
            parede = true;
            collideWithWallOnRightSide = facingRight;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (!col.isTrigger && col.gameObject.tag != "Parede")
        {
            parede = false;
        }


        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
