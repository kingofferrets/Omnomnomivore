using UnityEngine;
using System.Collections;

public class VictreeScript : MonoBehaviour {
    private bool victree;
	// Use this for initialization
	void Start () {
        victree = false;
	}
	
	// Update is called once per frame
    void OnGUI()
    {
        if (victree)
        {
            GUI.Box(new Rect(Screen.width/2, Screen.height/2, 90, 25), "Victree!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            victree = true;
        }
    }
}
