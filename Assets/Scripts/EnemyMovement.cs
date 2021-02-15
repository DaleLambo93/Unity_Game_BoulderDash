using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	//public Transform target;
	//public Transform enemyTransform;
	public float enemySpeed = 5.00f;

	private bool isCollided = false;

	// Update is called once per frame
	void Update () {

		if (isCollided)
			return;

		//transform.LookAt (target);
		transform.Translate (Vector3.forward * enemySpeed * Time.deltaTime); // Makes enemy continuouly move forward
	}

	public void SetEnemySpeed(float modifier)
	{
		enemySpeed = 5.0f + modifier;
	}

	// Enemy's collision
	void OnCollisionEnter(Collision col)
	{
		//rB.transform.Translate (Vector3.zero);
		if (col.gameObject.name == "Box") 
		{
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "Coin") 
		{
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "unitychan") 
		{
			isCollided = true;
		}
	}
}
