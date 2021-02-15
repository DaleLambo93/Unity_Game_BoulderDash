using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Music Manager used for playing music on scene load;
public class MusicManager : MonoBehaviour {

	public AudioClip mainTheme;
	public AudioClip menuTheme;

	public string sceneName;

//	void Start ()
//	{
//		OnLevelWasLoaded (0);
//	}
//		
//	void OnLevelWasLoaded (int sceneIndex) 
//	{
//		string newSceneName = SceneManager.GetActiveScene ().name;
//		if (newSceneName != sceneName) {
//			sceneName = newSceneName;
//			Invoke ("PlayMusic", 0.2f);
//		}
//	}

	void OnEnable() 
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable() 
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
	{
		string newSceneName = SceneManager.GetActiveScene ().name;
		if (newSceneName != sceneName) 
		{
			sceneName = newSceneName;
			Invoke ("PlayMusic", 0.2f);
		}
	}

	void PlayMusic() 
	{
		AudioClip clipToPlay = null;

		if (sceneName == "Menu") 
		{
			clipToPlay = menuTheme;
		}
		else if (sceneName == "Boulder Dash")
		{
			clipToPlay = mainTheme;
		}

		if (clipToPlay != null) 
		{
			AudioManager.instance.PlayMusic (clipToPlay, 2);
			Invoke ("PlayMusic", clipToPlay.length);
		}
	}
}
