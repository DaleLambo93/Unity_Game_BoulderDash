using UnityEngine;
using System.Collections;

public class ItemRotation : MonoBehaviour {

	public int rotateSpeed;

	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (Vector3.up * rotateSpeed * Time.fixedDeltaTime);	// Continuiously rotates items
	}
}
