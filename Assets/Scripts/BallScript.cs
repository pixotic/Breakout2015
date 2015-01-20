using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    public GameObject playerObject;
	// Use this for initialization
	void Start () {
	    //create initial force
        ballInitialForce = new Vector2(5000.0f, 15000.0f);

        //set to inactive
        ballIsActive = false;

        //ball position
        ballPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    //check for input
        if (Input.GetKeyDown(KeyCode.Space) == true) {
            //check if it's the first play
            if (!ballIsActive) {
                rigidbody2D.isKinematic = false;
                rigidbody2D.AddForce(ballInitialForce);
                //make ball active
                ballIsActive = !ballIsActive;
            }
        }

        //have ball follow paddle position on x axis if not active yet
        if (!ballIsActive && playerObject != null) {
            //get paddle x
            ballPosition.x = playerObject.transform.position.x;
            //apply new position to ball
            transform.position = ballPosition;
        }

        //If ball goes off the bottom of the screen
        if (ballIsActive && transform.position.y < -275) {
            ballIsActive = !ballIsActive;
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = 0;
            transform.position = ballPosition;
            rigidbody2D.isKinematic = true;
        }
	}
}
