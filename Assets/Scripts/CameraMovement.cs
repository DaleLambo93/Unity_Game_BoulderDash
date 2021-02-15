using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;
	private Vector3 animationOffset = new Vector3 ( 0, 5, 5);

	private float transition = 0.0f;
	private float animationDurarion = 2.0f;

	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("unitychan").transform;// Make sure there's a tag on the player first.
		startOffset = transform.position - lookAt.position;
	}

	// Update is called once per frame
	void Update () {
		moveVector = lookAt.position + startOffset;

		// X
		moveVector.x = 0;
		// Y
		moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

		if (transition > 1.0f) 
		{
			transform.position = moveVector;
		} 
		else 
		{
			//Animation at the start of game
			transform.position = Vector3.Lerp(moveVector + animationOffset,moveVector,transition);
			transition += Time.deltaTime * 1 / animationDurarion;
			transform.LookAt (lookAt.position + Vector3.up);
		}	
	}

	public void CameraRight()
	{

	}
}
