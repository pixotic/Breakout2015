using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    #region Declarations
    public float playerVelocity;
    public Vector3 playerPosition;
    public float boundary;
    #endregion

    // Use this for initialization
	void Start () {
        playerPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //playerVelocity = 10;
	    //horizontal movement
        playerPosition.x += Input.GetAxis("Horizontal") * playerVelocity;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            playerPosition.x += -1 * playerVelocity;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            playerPosition.x += 1 * playerVelocity;
        }


        //leave game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        

        //boundaries
        if (playerPosition.x < -boundary) {
            playerPosition.x = -boundary;
        } 
        if (playerPosition.x > boundary) {
            playerPosition.x = boundary;
        }

        //update object transform (position)
        transform.position = playerPosition;
	}
}
