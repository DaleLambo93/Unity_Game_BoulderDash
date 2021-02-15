using UnityEngine;
using System.Collections;

public class MenuCam : MonoBehaviour {

	public Transform currentTransform;
	public float speed = 0.1f;
	public int zoomFactor = 1;
	public Camera cameraComp;

	public GameObject player;
	public Animator animRef;
	public Animation[] clips;

	private Vector3 lastPos;

	// Use this for initialization
	void Start () {
		animRef = player.GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		// Changes cameras positon and rotate to the next mount
		transform.position = Vector3.Lerp (transform.position, currentTransform.position, speed);
		transform.rotation = Quaternion.Slerp (transform.rotation, currentTransform.rotation, speed);

		// Speed in change of position
		float velocity = Vector3.Magnitude (transform.position - lastPos);
		cameraComp.fieldOfView = 60 + velocity * zoomFactor;

		lastPos = transform.position;
	}

	public void setTransform(Transform newTransform)
	{
		currentTransform = newTransform;
		AudioManager.instance.PlaySound ("WaterDrop", transform.position);
		//animRef.Play ("WAIT01", -1, 0f);
	}
}
