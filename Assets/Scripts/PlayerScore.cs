using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

	public Text scoreText;
	public DeathMenu deathMenu;

	private float score = 0.0f;
	public bool isDead = false;
	private int collects = 0;

	//public int difficultyLvl = 1;
	//public int maxDifficultyLvl = 10;
	//public int scoreToNextLvl  = 10;

	// Use this for initialization
	void Start () {
		//scoreText.text = "Hello"; //Example of how it works	
	}

	// Update is called once per frame
	void Update () {
		
		if (isDead)
			return;

		//if (score >= scoreToNextLvl)
		//LevelUp ();

		//score += Time.deltaTime * difficultyLvl;
		score += Time.deltaTime;
		scoreText.text = ((int)score).ToString ();
		collects = UICollectables.totalAmountItemsCollected;
	}

	//void LevelUp (){
	//if (difficultyLvl == maxDifficultyLvl)
	//return;

	//scoreToNextLvl *= 2;
	//difficultyLvl++;

	//GetComponent<PlayerMove>().SetSpeed (difficultyLvl);
	//GetComponent<EnemyPath>().SetEnemySpeed (difficultyLvl);
	//}

	public void OnDeath()
	{
		isDead = true;

		//  Checks if player has score is higher and if items collected is higher
		if (PlayerPrefs.GetFloat ("Highscore") < score && PlayerPrefs.GetFloat ("MaxItems") < collects) {
			PlayerPrefs.SetFloat ("Highscore", score);
			PlayerPrefs.SetInt ("MaxItems", collects);
		}

		deathMenu.ToggleMenu (score,collects);
	}
}
