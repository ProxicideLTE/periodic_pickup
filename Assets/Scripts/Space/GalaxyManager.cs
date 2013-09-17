using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalaxyManager : MonoBehaviour {
	
	// Instance variables.
	public GameObject					window;
	
	public tk2dTextMesh					lbl_time;
	
	public float						time_available;
		
	private PlayerScript				player;
	
	private bool						in_volume;
	private float						time;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		
		// Instantiate variables.
		this.window.SetActive(false);
		this.player = FindObjectOfType(typeof (PlayerScript)) as PlayerScript;
		this.in_volume = true;
		this.time = this.time_available;
		
		this.lbl_time.text = this.time+ " s";
		this.lbl_time.Commit();
		
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {
		
		// If the player is out of the volume and the game is not paused. 
		if (!this.in_volume && !UIPause.getInstance().isGamePaused()) {
			
			// Decrement time.
			this.time -= Time.deltaTime;
			
			// Update label.
			this.lbl_time.text = this.time+ " s";
			this.lbl_time.Commit();
			
			if (this.time <= 0)
				Application.LoadLevel("game_over");
			
		}
		
	}
	
	/// <summary>
	/// Raises the trigger exit event.
	/// </summary>
	/// <param name='c'>
	/// C.
	/// </param>
	void OnTriggerExit(Collider c) {
		this.exitingVolume();
		print ("Exiting the volume");	
	}
	
	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name='c'>
	/// C.
	/// </param>
	void OnTriggerEnter(Collider c) {
		this.enteringVolume();
		this.resetTimer();
		print ("Entering the volume");	
	}
	
	/// <summary>
	/// Set a flag that the player is outside the trigger volume.
	/// </summary>
	public void exitingVolume() {
		this.in_volume = false;
		this.showWarning();
		
	}
	
	/// <summary>
	/// Set a flag that the player is in the trigger volume
	/// </summary>
	public void enteringVolume() {
		this.in_volume = true;
		this.hideWarning();
	}
	
	/// <summary>
	/// Shows the warning.
	/// </summary>
	private void showWarning() {
		this.window.SetActive(true);
	}
	
	/// <summary>
	/// Hides the warning.
	/// </summary>
	private void hideWarning() {
		this.window.SetActive(false);	
	}
	
	/// <summary>
	/// Resets the timer.
	/// </summary>
	public void resetTimer() {
		this.time = this.time_available;	
	}
	
}
