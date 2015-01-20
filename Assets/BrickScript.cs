using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

    public int hitsToKill;
    public int points;
    private int numberOfHits;

    
    public Sprite twoHealth;
    public Sprite oneHealth;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        numberOfHits = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
        //This should probably go somewhere else...
        switch (hitsToKill-numberOfHits) {
            case 2:
                spriteRenderer.sprite = twoHealth;
                break;
            case 1:
                spriteRenderer.sprite = oneHealth;
                break;
            default:
                break;
        }

	}

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ball") {
            numberOfHits++;

            if (numberOfHits == hitsToKill) {
                //destroy the object
                Destroy(this.gameObject);
            }

        }
    }



}
