using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
    public int index;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Personagem"){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name) ;
            player monoPlayer = col.transform.gameObject.GetComponent<player>();
            if (monoPlayer != null)
                monoPlayer.setCheckpoint(this.transform.position, this.index);
        }
    }
}
