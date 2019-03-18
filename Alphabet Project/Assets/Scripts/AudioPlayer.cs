using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour {

	public Sound[] sounds;

	public static AudioPlayer instance;

	void Awake () {
		// Check if this is the first instance or not
		if(instance == null) 
		{
			instance = this;
		} 
		else 
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);

		// Creates an audio source for each audio clip 
		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

		}
	}
	
	// Plays the specific audio clip
	public void PlaySound (string name) {
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s != null) s.source.Play();
	}
}
