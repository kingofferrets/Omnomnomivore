using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {
    private int respawnTimer;
    public int respawnTime;
    private bool available;
    public SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
        respawnTimer = 0;
        available = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (respawnTimer > 0)
        {
            respawnTimer--;
        }
        else if (respawnTimer == 0)
        {
            respawn();
        }
	}

    void respawn()
    {
        available = true;
        sprite.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && available)
        {
            MoveScript move = other.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.powerUp(0,10, sprite.color);
            }
            available = false;
            sprite.enabled = false;
            respawnTimer = respawnTime;
        }
    }
}
