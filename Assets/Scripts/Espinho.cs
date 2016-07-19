using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Espinho : MonoBehaviour {

	// Use this for initialization

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		
		if (col.tag == "Personagem"){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name) ;
            if (col.transform.gameObject.GetComponent<player>() != null)
                col.transform.gameObject.GetComponent<player>().die();
        }
	}
}