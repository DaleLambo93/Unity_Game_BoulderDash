using UnityEngine;
using System.Collections;

public class SwipeManager : MonoBehaviour {

	public GameObject player;

	public float timeMax;
	public float swipeDistMin;

	float timeStart;      //Initial finger touch onscreen   
	float timeEnd;        //Lift finger touch from screen
	float swipeDist;
	float swipeTime;

	Vector3 startPos;     //Where finger is initially touched onscreen
	Vector3 endPos;       //Where finger is lifted offscreen.

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//Check if finger has touched anywhere onscreen
		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);                 //Storing 0 first touch

			//Check when finger is touched onscreen
			if (touch.phase == TouchPhase.Began) {
				timeStart = Time.time;                        //Stores time of initial touch
				startPos = touch.position;                    //Stores position of initial touch
			} 
			//Check when finger is lifted offscreen
			else if (touch.phase == TouchPhase.Ended) {
				timeEnd = Time.time;                         //Stores time of finishing touch
				endPos = touch.position;                     //Stores position of finishing touch

				swipeDist = (endPos - startPos).magnitude;  //Stores distance between two positions
				swipeTime = timeEnd - timeStart;            //Stores the difference between two times

				if (swipeTime < timeMax && swipeDist > swipeDistMin) {
					swipeCheck ();
				}
			}
		}
	}

	void swipeCheck() {
		Vector2 distance = endPos - startPos;

		//Checks for any horizontal swipes e.g. right and left
		if (Mathf.Abs (distance.x) > Mathf.Abs (distance.y)) {
			Debug.Log ("Horizontal Swipe");

			if (distance.x > 0) {
				Debug.Log ("Right Swipe");
				//player.GetComponent<PlayerMove> ().RotateRight (); // Turns player Right
			}
			if (distance.x < 0) {
				Debug.Log ("Left Swipe");
				//player.GetComponent<PlayerMove> ().RotateLeft (); // Turns player Left
			}
		}
		//Checks for any vertical swipes e.g. up and down
		else if (Mathf.Abs (distance.x) < Mathf.Abs (distance.y)) {
			Debug.Log("Vertical Swipe");

			if (distance.y > 0) {
				Debug.Log("Up Swipe");
				player.GetComponent<PlayerMovement> ().Jump ();

			}
			if (distance.y < 0) {
				Debug.Log("Down Swipe");
				player.GetComponent<PlayerMovement> ().Slide ();
			}
		}
	}
}
