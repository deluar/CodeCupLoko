using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Button button = this.transform.parent.parent.GetComponent<Button>();

        if (col.gameObject.tag == "Personagem" && button != null)
            button.playerIn();

        if (col.gameObject.tag == "Caixa" && button != null)
            button.boxIn();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Button button = this.transform.parent.parent.GetComponent<Button>();

        if (col.gameObject.tag == "Personagem" && button != null)
            button.playerOut();

        if (col.gameObject.tag == "Caixa" && button != null)
            button.boxOut();
    }
}
