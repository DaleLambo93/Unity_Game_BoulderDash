using UnityEngine;
using System.Collections;

public class AccelerometerManager : MonoBehaviour {

	public float accelX;
	public float maxX = 0.1f;
	public float minX = -0.1f;

	public void AccelerometerMove()
	{
		accelX = -Input.acceleration.x;
		float newX = Mathf.Clamp (accelX, minX, maxX);
		//Debug.Log (temp);
		transform.Translate(newX,0,0);
	}
}
