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
        
        speed = 3;
        speedRunning = 6;

        collideWithWallOnRightSide = false;
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetJoystickNames().Length == 0)
            keyBoardCalls();
        //else
            joystickCalls();

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

        //if (!parede){
            if (Input.GetKey(KeyCode.LeftShift) || (Input.GetKey(KeyCode.Z)))
                transform.Translate(new Vector3(movimentoX * speedRunning * Time.deltaTime, 0, 0));
            else
                transform.Translate(new Vector3(movimentoX * speed * Time.deltaTime, 0, 0));
        //}

        if ((movimentoX > 0 && !facingRight) || (movimentoX < 0 && facingRight)){
            Flip();
        }

        if ((Input.GetKey(KeyCode.Space) || (Input.GetAxisRaw("Vertical") > 0)) && !isJumping && isGrounded)
            jump();

        if ((collideWithWallOnRightSide && !facingRight) || (!collideWithWallOnRightSide && facingRight))
            parede = false;

        //DEBUG KEYS
        //foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        //{
        //    if (Input.GetKey(vKey))
        //    {
        //        print(vKey.ToString());

        //    }
        //}
    }

    void joystickCalls(){
        movimentoX = Input.GetAxisRaw("Horizontal");

        //if (!parede){
            if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Joystick1Button3))
                transform.Translate(new Vector3(movimentoX * speedRunning * Time.deltaTime, 0, 0));
            else
                transform.Translate(new Vector3(movimentoX * speed * Time.deltaTime, 0, 0));
        //}

        if ((movimentoX > 0 && !facingRight) || (movimentoX < 0 && facingRight)){
            Flip();
        }

        if ((Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick1Button2)) && !isJumping && isGrounded)
            jump();

        if ((collideWithWallOnRightSide && !facingRight) || (!collideWithWallOnRightSide && facingRight))
            parede = false;
    }

    void Flip(){
        //gameObject.transform.Rotate(new Vector3(0, 180, 0));

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
        if (col.gameObject.tag == "Ground"){
            isJumping = false;
        }

        if(!col.isTrigger && col.gameObject.tag == "Parede"){
            parede = true;
            collideWithWallOnRightSide = facingRight;
        }
    }

    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (!col.isTrigger && col.gameObject.tag == "Parede")
        {
            parede = false;
        }


        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
