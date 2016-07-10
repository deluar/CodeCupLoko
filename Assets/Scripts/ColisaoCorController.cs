using UnityEngine;
using System.Collections;

public class ColisaoCorController : MonoBehaviour {

	public bool branco;
	private fundo fundo;
	private Rigidbody2D rigidBody;
	public GameObject	colisor;
    public player player;

    void Start () {
		fundo = FindObjectOfType (typeof(fundo)) as fundo;
        player = FindObjectOfType(typeof(player)) as player;
//		rigidBody = GetComponent<Rigidbody2D>();
//		rigidBody.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
	}
	
	// Update is called once per frame
	void Update () {

		if ((branco && fundo.padrao) || (!branco && !fundo.padrao)) {
			colisor.SetActive (false);
            //player.parede = false;
//			rigidBody.isKinematic = false;
//			rigidBody.collisionDetectionMode = CollisionDetectionMode2D.Discrete;

		} 
		else {
			colisor.SetActive (true);
//			rigidBody.isKinematic = true;
//			rigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		}
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Personagem")
        {
            player.parede = false;
        }
        //else if (col.gameObject.tag == "Plataforma")
        //{
        //    //rbPlayer.transform.parent = col.transform;
        //    onPlataform = true;
        //    plataformLastPosition = col.transform.position;
        //    print("3");
        //}

    }
}
