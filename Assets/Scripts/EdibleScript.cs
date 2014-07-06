using UnityEngine;
using System.Collections;

public class EdibleScript : MonoBehaviour {
    private Color origColor;
    public Color highlightColor;
    public SpriteRenderer sprite;

    private int highlightCountdown;
    public int maxHighlightCountdown;

	// Use this for initialization
	void Start () {
        origColor = sprite.color;
        highlightCountdown = 0;
	}

    void Update()
    {
        if (highlightCountdown > 0)
        {
            highlightCountdown--;
        }
        else if (sprite.color != origColor)
        {
            sprite.color = origColor;
        }
    }

    public void highlight()
    {
        sprite.color = highlightColor;
        highlightCountdown = maxHighlightCountdown;
    }
}
