using UnityEngine;
using System.Collections;

public class Desativar : MonoBehaviour {

    public GameObject colisor;
    public GameObject colisor2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        colisor.SetActive(false);
        colisor2.SetActive(true);

    }

    void OnTriggerExit2D(Collider2D col){
        colisor.SetActive(true);
        colisor2.SetActive(false);

    }
}
