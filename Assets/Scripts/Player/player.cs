using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	private	float 		speed;
    private float       speedRunning;
    private  float       movimentoX;

    private  bool         correndo; //Alteracao de JP.
    private  bool        jumping;
    private  int         jumpForce;
    private  bool        grounded;
    private bool        collideWithWallOnRightSide;

    private bool         parede;
	private	bool 		facingRight;

    private Vector3 lastCheckPoint;
    private int lastCheckPointIndex;

	// Use this for initialization
	void Start () {
        jumping = false;
        jumpForce = 20;
        
        speed = 3;
        speedRunning = 6;

        collideWithWallOnRightSide = false;

        lastCheckPointIndex = -1;
        setCheckpoint(this.gameObject.transform.position, 0);

        facingRight = true;
    }
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetJoystickNames().Length == 0)
            keyBoardCalls();
        //else
            joystickCalls();

    }

    public float getMovimentoX(){
        return movimentoX;
    }

    public bool isRunning(){
        return correndo;
    }

    public bool isGrounded(){
        return grounded;
    }

    public bool isJumping(){
        return jumping;
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
        {
            transform.Translate(new Vector3(movimentoX * speedRunning * Time.deltaTime, 0, 0));
            correndo = true; //Alteracao de JP.
        }
        else {
            transform.Translate(new Vector3(movimentoX * speed * Time.deltaTime, 0, 0));
            correndo = false; //Alteracao de JP.
        }
        //}

        if ((movimentoX > 0 && !facingRight) || (movimentoX < 0 && facingRight)){
            Flip();
        }

        if ((Input.GetKey(KeyCode.Space) || (Input.GetAxisRaw("Vertical") > 0)) && !jumping && isGrounded())
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

        if ((Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick1Button2)) && !jumping && isGrounded())
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
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);
        jumping = true;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Ground"){
            jumping = false;
        }

        if(!col.isTrigger && col.gameObject.tag == "Parede"){
            parede = true;
            collideWithWallOnRightSide = facingRight;
        }
    }

    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Ground"){
            grounded = true;
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
            grounded = false;
        }
    }

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			grounded = false;
		}
	}

    public void setCheckpoint(Vector3 checkPoint, int checkPointIndex){
        if(lastCheckPointIndex < checkPointIndex){
            lastCheckPoint = checkPoint;
            lastCheckPointIndex = checkPointIndex;
        }
    }

    public void die() {
        this.gameObject.transform.position = lastCheckPoint;
    }
}
