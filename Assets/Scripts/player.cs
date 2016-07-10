using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public	Rigidbody2D	rbPlayer;
	public	float 		speed;
    public  float       speedRunning;
	public	float 		movimentoX;

    public  bool        isJumping;
    public  int         jumpForce;

    //public  bool        onPlataform;
    //public  Vector2     plataformLastPosition;

	public	bool 		facingRight;

	// Use this for initialization
	void Start () {
        isJumping = false;
        jumpForce = 20;

        //onPlataform = false;
        
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

        if(Input.GetKey(KeyCode.LeftShift))
            rbPlayer.velocity = new Vector2(movimentoX * speedRunning, rbPlayer.velocity.y);
        else
            rbPlayer.velocity = new Vector2(movimentoX * speed, rbPlayer.velocity.y);


        if (movimentoX > 0 && !facingRight)
        {
            Flip();
        }
        else if (movimentoX < 0 && facingRight)
        {
            Flip();
        }

        if ((Input.GetKey(KeyCode.Space) || (Input.GetAxisRaw("Vertical") > 0)) && !isJumping)
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
        //else if (col.gameObject.tag == "Plataforma")
        //{
        //    //rbPlayer.transform.parent = col.transform;
        //    onPlataform = true;
        //    plataformLastPosition = col.transform.position;
        //    print("3");
        //}

    }

    //void onTriggerStay2D(Collider2D col){
    //    if (col.gameObject.tag == "Plataforma")
    //    {
    //        int newX = (int)(rbPlayer.transform.position.x + (col.transform.position.x - plataformLastPosition.x));
    //        int newY = (int)(rbPlayer.transform.position.y + (col.transform.position.y - plataformLastPosition.y));
    //
    //        int incX = (int)(col.transform.position.x - plataformLastPosition.x);
    //        int incY = (int)(col.transform.position.y - plataformLastPosition.y);
    //
    //        //rbPlayer.transform.position = new Vector2(newX, newY);
    //        rbPlayer.velocity = new Vector2(incX, incY);
    //
    //        plataformLastPosition = col.transform.position;
    //        print("4");
    //        print("Inc X = " + incX);
    //        print("Inc Y = " + incY);
    //        print(incX);
    //    }
    //}

    void OnTriggerExit2D(Collider2D col)
    {
        //if (col.gameObject.tag == "Plataforma")
        //{
        //    //rbPlayer.transform.parent = null;
        //    onPlataform = false;
        //    print("5");
        //}
    }

    /*
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
