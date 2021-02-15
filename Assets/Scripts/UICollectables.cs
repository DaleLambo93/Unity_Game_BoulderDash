using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UICollectables : MonoBehaviour {

	public static int totalAmountItemsCollected;
	public static int playerItemsCollected;
	public static int touchItemsCollected;
	public Text collectablesText;

	// Update is called once per frame
	void Update () {
		playerItemsCollected = PlayerCollision.itemsCollected;
		touchItemsCollected = TouchInput.itemsCollected;

		// Adds Player items collected with touch items collected.
		totalAmountItemsCollected = playerItemsCollected + touchItemsCollected;
		//Debug.Log (totalAmountItemsCollected);
		collectablesText.text = totalAmountItemsCollected.ToString();
	}
}
