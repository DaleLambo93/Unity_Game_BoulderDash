using UnityEngine;
using System.Collections;

//Audio Manager is used to set up the sounds and volume for different audio elements/channels
public class AudioManager : MonoBehaviour {

	public enum AudioChannel {Master, Sfx, Music};

	public float masterVolumePercent { get; private set; }
	public float sfxVolumePercent { get; private set; }
	public float musicVolumePercent { get; private set; }

	AudioSource sfx2DSource;
	AudioSource[] musicSources;
	int activeMusicSourceIndex;

	public static AudioManager instance;

	Transform audioListener;
	Transform playerT;

	AudioLibrary library; //Reference to the audioLibrary

	void Awake()
	{
		// Checks if instance is a duplicate if it is destroy it.
		if (instance != null) 
		{
			Destroy (gameObject);
		} 
		else 
		{
			instance = this;
			DontDestroyOnLoad (gameObject);// Allows audioManager to persist across scene changes

			library = GetComponent<AudioLibrary> ();

			musicSources = new AudioSource[2];
			for (int i = 0; i < 2; i++) {
				GameObject newMusicSource = new GameObject ("Music source" + (i + 1));
				musicSources [i] = newMusicSource.AddComponent<AudioSource> ();
				newMusicSource.transform.parent = transform;
			}

			GameObject newSfx2DSource = new GameObject ("2D Sfx source");
			sfx2DSource = newSfx2DSource.AddComponent<AudioSource> ();
			newSfx2DSource.transform.parent = transform;

			audioListener = FindObjectOfType<AudioListener> ().transform;

			if (FindObjectOfType<PlayerMovement>() != null)
			{
				playerT = FindObjectOfType<PlayerMovement> ().transform; // May need changing
			}

			masterVolumePercent = PlayerPrefs.GetFloat ("master volume", 1);
			sfxVolumePercent = PlayerPrefs.GetFloat ("sfx volume", 1);
			musicVolumePercent = PlayerPrefs.GetFloat ("music volume", 1);
		}
	}

	void Update() 
	{
		if (playerT != null)
		{
			audioListener.position = playerT.position;
		}
	}

	//Method for setting volumes for differnt channels
	public void SetVolume(float volumePercent, AudioChannel channel)
	{
		switch (channel) 
		{
		case AudioChannel.Master:
			masterVolumePercent = volumePercent;
			break;
		case AudioChannel.Sfx:
			sfxVolumePercent = volumePercent;
			break;
		case AudioChannel.Music:
			musicVolumePercent = volumePercent;
			break;
		}

		//update volume of both music sources whenever the volume changes
		musicSources [0].volume = musicVolumePercent * masterVolumePercent;
		musicSources [1].volume = musicVolumePercent * masterVolumePercent;

		// Saves volumes to players preferences so when the game load it remembers what its set too.
		PlayerPrefs.SetFloat ("master volume", masterVolumePercent);
		PlayerPrefs.SetFloat ("sfx volume", sfxVolumePercent);
		PlayerPrefs.SetFloat ("music volume", musicVolumePercent);
		PlayerPrefs.Save ();

	}

	public void PlayMusic(AudioClip clip, float fadeDuration = 1)
	{
		activeMusicSourceIndex = 1 - activeMusicSourceIndex;
		musicSources [activeMusicSourceIndex].clip = clip;
		musicSources [activeMusicSourceIndex].Play ();

		StartCoroutine (AnimateMusicCrossfade (fadeDuration));
	}

	// Method for playing sound based on clip name
	public void PlaySound(AudioClip clip, Vector3 pos)
	{
		if (clip != null) 
		{
			AudioSource.PlayClipAtPoint (clip, pos, sfxVolumePercent * masterVolumePercent);
		}
	}

	//Alternative method that finds the correct clip from the audioLibrary
	public void PlaySound(string soundName, Vector3 pos)
	{
		PlaySound (library.GetClipFromName (soundName), pos);
	}

	//Sounds that need to be 2D
	public void PlaySound2D(string soundName)
	{
		sfx2DSource.PlayOneShot (library.GetClipFromName (soundName), sfxVolumePercent * masterVolumePercent);
	}

	// Music fade
	IEnumerator AnimateMusicCrossfade(float duration) 
	{
		float percent = 0;

		while (percent < 1) {
			percent += Time.deltaTime * 1 / duration;
			musicSources [activeMusicSourceIndex].volume = Mathf.Lerp (0, musicVolumePercent * masterVolumePercent, percent);
			musicSources [1-activeMusicSourceIndex].volume = Mathf.Lerp (musicVolumePercent * masterVolumePercent, 0, percent);
			yield return null;
		
		}
	}
}
