using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	public static int itemsCollected;

	void Start()
	{
		itemsCollected = 0;
	}

	// Update is called once per frame
	void Update () {
		// Condition checks if we are touching the screen and whether the touch has just began.
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
		{
			ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position); // Takes the point onscreen and converts it to a ray

			Debug.DrawRay (ray.origin, ray.direction * 20, Color.red); //Shows where ray is in scene.

			// If the ray hits something it will store it inside the Hit variable / ray also has infinite length
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) 
			{
				// Checks if the raycast has hit the cubes.
				if (hit.collider.gameObject.tag == "Coin" && Time.timeScale == 1)
				{
					//Debug.Log (hit.collider.gameObject.tag);
					itemsCollected++;	
					//Debug.Log (itemsCollected);
					Destroy (hit.transform.gameObject); // Destroys the object that the ray hits
				}
			}
		}	
	}
}
