using UnityEngine;
using System.Collections;

public class EnemyRotate : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (Vector3.right * Time.deltaTime);	
	}

}
