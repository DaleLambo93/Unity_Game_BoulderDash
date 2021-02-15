using UnityEngine;
using System.Collections;

// Procedurally generates items based on the players position
public class ItemSpawner : MonoBehaviour {

	PlayerMovement playerMove;
	public GameObject player;
	public GameObject[] items;
	public float ItemSpawnTimer = 14.0f;

	void Start()
	{
		playerMove = player.GetComponent<PlayerMovement> ();
	}

	// Update is called once per frame
	void Update () {
		ItemSpawnTimer -= Time.deltaTime;

		// Checks if player is dead to deteremine whether to spawn more Items
		if (ItemSpawnTimer < 0.01 && playerMove.isDead == false) 
		{
			// Check to delete spawned items 
			SpawnItems ();

		}
	}

	// Creates the items from prefabs 
	void SpawnItems()
	{
		Instantiate (items [(Random.Range (0, items.Length))], new Vector3 (Random.Range (-1, 2), Random.Range (2, 4), player.transform.position.z + 15), Quaternion.identity);

		ItemSpawnTimer = Random.Range (4.0f, 12.0f);
	}
		 
}
