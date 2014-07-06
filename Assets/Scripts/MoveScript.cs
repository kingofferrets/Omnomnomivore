using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public float speed;
	public Transform pos;
    public BoxCollider trigger;
    public SpriteRenderer sprite;
    private Color origColor;
    private int durability;
    private int teethType;
    private Vector3 destination;
	// Use this for initialization
	void Start () {
        durability = 0;
        teethType = -1;
        origColor = sprite.color;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetAxis("Vertical") != 0) {
			pos.position = new Vector3(pos.position.x, pos.position.y + (speed * Input.GetAxis ("Vertical")), pos.position.z);
            if (Input.GetAxis("Vertical") > 0)
            {
                trigger.center = new Vector3(0, 0.75f, 0.5f);
            }
            else
            {
                trigger.center = new Vector3(0, -0.75f, 0.5f);
            }
		}
		if(Input.GetAxis("Horizontal") != 0) {
			pos.position = new Vector3(pos.position.x + (speed * Input.GetAxis ("Horizontal")), pos.position.y, pos.position.z);
            if (Input.GetAxis("Horizontal") > 0)
            {
                trigger.center = new Vector3(0.75f, 0, 0.5f);
            }
            else
            {
                trigger.center = new Vector3(-0.75f, 0, 0.5f);
            }
		}
	}

	void OnTriggerStay (Collider other) {
        if (Input.GetButton("Fire2") && other.gameObject.tag == "Nommable")
        {
            EdibleScript nomscript = other.gameObject.GetComponent<EdibleScript>();
            if (nomscript != null)
            {
                nomscript.highlight();
            }
            if (Input.GetButton("Fire1") && teethType != -1)
            {
                eatEnvironment(nomscript);
            }
        }
	}

    public void powerUp(int newTeeth, int newDur, Color newCol)
    {
        teethType = newTeeth;
        durability = newDur;
        sprite.color = newCol;
    }

    void eatEnvironment(EdibleScript nomscript)
    {
        durability--;
        if(durability < 1) {
            teethType = -1;
            sprite.color = origColor;
        }
        Destroy(nomscript.gameObject);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 90, 25), "Durability: " + durability);
    }
}
