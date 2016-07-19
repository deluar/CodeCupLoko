using UnityEngine;
using System.Collections;

public class PlataformButton : MonoBehaviour {
    public GameObject botao;
    private GameObject plataforma;
    private Button scriptBotao;

	// Use this for initialization
	void Start () {
        plataforma = this.transform.GetChild(0).gameObject;
        scriptBotao = botao.transform.gameObject.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
        plataforma.SetActive(scriptBotao.isPressed);
	}

}
