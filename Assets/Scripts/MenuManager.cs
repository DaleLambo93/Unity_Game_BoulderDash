using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public Slider[] volumeSliders;
	public GameObject creditsHolder;
	public GameObject creditText;
	public float speed;
	public Vector3 startingPos;
	public GameObject[] buttons;
	public Text highscoreText;
	public Text maxItemsText;

	void Start()
	{
		volumeSliders [0].value = AudioManager.instance.masterVolumePercent;
		volumeSliders [1].value = AudioManager.instance.musicVolumePercent;
		volumeSliders [2].value = AudioManager.instance.sfxVolumePercent;
		creditsHolder.SetActive (false); // Not visibale on start
		startingPos = creditText.transform.position;

		// Sets scores with values saved in player prefs
		highscoreText.text = "Highscore: " + ((int)PlayerPrefs.GetFloat ("Highscore")).ToString();
		maxItemsText.text = "Max Items: " + PlayerPrefs.GetInt("MaxItems");
	}

	public void StartGame()
	{
		SceneManager.LoadScene ("Boulder Dash"); // Loads game scene from menu
	}

	public void Options()
	{
		//AudioManager.instance.PlaySound ("WaterDrop", transform.position);
	}

	public void Leaderboards()
	{
		//AudioManager.instance.PlaySound ("WaterDrop", transform.position);
	}

	public void Exit()
	{
		Application.Quit ();
		//System.Diagnostics.Process.GetCurrentProcess ().Kill ();
	}	

	public void CreditsMenu()
	{
		creditsHolder.SetActive (true);
		AudioManager.instance.PlaySound2D ("WaterDrop");
		StartCoroutine (MoveOverSeconds (creditText, new Vector3 (creditText.transform.position.x, creditText.transform.position.x + 5.5f, creditText.transform.position.z), 10.0f));
	}

	public void SetMasterVolume(float value) 
	{
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Master);
	}

	public void SetMusicVolume(float value)
	{
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Music);
	}

	public void SetSfxVolume(float value)
	{
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Sfx);
	}

	// Moves Credit text over 10 seconds for initial position
	public IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 end, float seconds)
	{
		float elapsedTime = 0;
		while (elapsedTime < seconds)
		{
			objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;

			DisableButtons ();

			yield return new WaitForEndOfFrame();
		}

		EnableButtons ();
		creditsHolder.SetActive (false);
	}

	// Used so player cant access buttons while in credits
	private void DisableButtons()
	{
		buttons [0].GetComponent<Button> ().interactable = false;
		buttons [1].GetComponent<Button> ().interactable = false;
		buttons [2].GetComponent<Button> ().interactable = false;
		buttons [3].GetComponent<Button> ().interactable = false;
		buttons [4].GetComponent<Button> ().interactable = false;
	}

	// Used so player can re-access buttons after credits
	private void EnableButtons()
	{
		buttons [0].GetComponent<Button> ().interactable = true;
		buttons [1].GetComponent<Button> ().interactable = true;
		buttons [2].GetComponent<Button> ().interactable = true;
		buttons [3].GetComponent<Button> ().interactable = true;
		buttons [4].GetComponent<Button> ().interactable = true;
	}

}
