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

    public bool         parede;

	public	bool 		facingRight;

	// Use this for initialization
	void Start () {
        isJumping = false;
        jumpForce = 20;
        
        speed = 6;
        speedRunning = 10;
    }
	
	// Update is called once per frame
	void Update () {
        keyBoardCalls();

	}

    void keyBoardCalls()
    {
        movimentoX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift)){
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
    }

	void Flip(){

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
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

    }

    void OnTriggerStay2D(Collider2D col){

        if (!col.isTrigger && col.gameObject.tag != "Parede")
        {
            parede = true;
        }

        if(col.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (!col.isTrigger && col.gameObject.tag != "Parede")
        {
            parede = false;
        }

        if(col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
