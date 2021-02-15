using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public Text scoreText;
	public Text collectables;
	public Image bgImage;

	private bool isShown = false;
	private float transition = 0.0f;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isShown)
			return;

		transition += Time.deltaTime;
		bgImage.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, transition);
	
	}

	// Toggle for death menu
	public void ToggleMenu(float score, int collect)
	{
		gameObject.SetActive (true);
		scoreText.text = ((int)score).ToString();
		collectables.text = collect.ToString ();
		isShown = true;
		// Remember to stop or restart music in here!!!
	}

	// Restarts the game and resets items score
	public void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		UICollectables.totalAmountItemsCollected = 0;
	}

	// Reloads the main menu
	public void MainMenu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
