using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	
	private static MusicManager			instance;
	
	public AudioClip					pickup;
	
	public static MusicManager getInstance() {
		
		// Initialize instance for the singleton.
		if (instance == null)
			instance = GameObject.FindObjectOfType(typeof(MusicManager)) as MusicManager;
				
		return instance;
		
	}
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void playMusic(AudioClip clip) {
		if (clip != null) {
			audio.clip = clip;
			audio.loop = true;
			audio.volume = 0.75f;
			audio.Play();
		}
	}
	
	public void stopMusic() {
		audio.Stop();
	}
	
	public void playPickup() {
		audio.PlayOneShot(this.pickup);	
	}
	
}
