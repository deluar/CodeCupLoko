using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

    public string nome;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKey(KeyCode.Return)) {
            SceneManager.LoadScene(nome);
        }
       
	}
}
