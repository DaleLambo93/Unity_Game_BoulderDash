using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioLibrary : MonoBehaviour {
	
	public SoundGroup[] soundGroups;

	Dictionary<string, AudioClip[]> groupDictionary = new Dictionary<string, AudioClip[]> ();

	void Awake()
	{
		// Loop through all out sound groups
		foreach (SoundGroup soundGroup in soundGroups) 
		{
			groupDictionary.Add (soundGroup.groupID, soundGroup.group); //Adds sound groups to dictionary
		}
	}
		
	public AudioClip GetClipFromName(string name)
	{
		if (groupDictionary.ContainsKey (name)) 
		{
			AudioClip[] sounds = groupDictionary [name];
			return sounds [Random.Range (0, sounds.Length)];
		}
		return null;
	}

	//Class for storing sound in groups
	[System.Serializable]
	public class SoundGroup 
	{
		public string groupID;
		public AudioClip[] group; // Array for all sounds in that group
	}
}
