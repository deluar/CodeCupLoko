using UnityEngine;
using System.Collections;

public class ColisaoCorController : MonoBehaviour {

	public bool branco;
	private fundo fundo;
	private Rigidbody2D rigidBody;
	public GameObject	colisor;
    private player player;
    public bool isColliding;

    void Start () {
		fundo = FindObjectOfType (typeof(fundo)) as fundo;
        player = FindObjectOfType(typeof(player)) as player;
    }
	
	// Update is called once per frame
	void Update () {
        isColliding = ((branco && !fundo.padrao) || (!branco && fundo.padrao));
		colisor.SetActive (isColliding);
        
	}
}
