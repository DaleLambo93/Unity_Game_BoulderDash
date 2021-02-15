using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
	public static int itemsCollected;

	void Start()
	{
		itemsCollected = 0;
	}

	//Player collision
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Coin") 
		{
			Destroy (col.gameObject);
			itemsCollected++;
			//Debug.Log (itemsCollected);
		}
	}
}
