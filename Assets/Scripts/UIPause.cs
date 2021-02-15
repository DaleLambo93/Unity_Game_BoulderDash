using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPause : MonoBehaviour {

	public Text uiText;
	public Text pausedText;

	public void Pause (){

		// Game is Running
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			uiText.text = "►";
			pausedText.text = "[Paused]";
			Debug.Log ("Paused");
			//GetComponent<EnableAcc> ().DisableAccelerometer ();
		} 
		// Game is paused
		else if (Time.timeScale == 0) {
			Time.timeScale = 1;
			uiText.text = "I I";
			pausedText.text = "";
			//GetComponent<EnableAcc> ().EnableAccelerometer ();
		}
	}
}
