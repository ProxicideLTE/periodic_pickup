using UnityEngine;
using System.Collections;

/// <summary>
/// This class manages the time available for the player to travel.
/// </summary>
public class TimeManager : MonoBehaviour {
	
	// Instance variables.
	static private TimeManager			instance;

	public float						time_avaiable;
	public PlayerScript					player;
	public Planet						home_planet;
	public SphereCollider				home_planet_collider;
		
	private bool						pause;
	private float						time_left;
	
	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <returns>
	/// The instance.
	/// </returns>
	public static TimeManager getInstance() {	
		
		// Initialize instance for the singleton.
		if (instance == null)
			instance = GameObject.FindObjectOfType(typeof(TimeManager)) as TimeManager;
				
		return instance;
		
	}
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		this.pause = true;
		this.time_left = this.time_avaiable;
	}
	
	// Update is called once per frame
	void Update () {
		
		// As long as the timer isn't paused, resume the countdown.
		if (!pause) {
			this.time_left -= Time.deltaTime;
			
			if (this.time_left <= 0) 
				this.loadHomePlanet();
			
		}
		
	}
	
	/// <summary>
	/// Loads the home planet when the timer reaches zero.
	/// </summary>
	private void loadHomePlanet() {
		
		// Set timer.
		this.pauseTimer();
		this.resetTimer();
		
		// Set the recent planet to the home planet now.
		this.player.recent_planet = this.home_planet;
		this.player.recent_planet_collider = this.home_planet_collider;
		
		// Load the player back to the planet.
		this.player.changeState(new PlanetPlayerState(this.player));
		this.player.incrementWeekCount();
		
		// Show the player the resources gathered in the run, if any were collected.
		if (this.player.countGatheredElements() > 0) {
			UIPlanet.getInstance().showPlanetUI();
			UIPlanet.getInstance().showGatheredResources();
			UIPlanetGatheredElements.getInstance().setGatheredElements(this.player.getGatheredElements());
			UIPlanetGatheredElements.getInstance().showGatheredElements();
		}
		
		// Otherwise show the weekly deductions window.
		else {
			UIPlanet.getInstance().showPlanetUI();
			UIPlanet.getInstance().showWeeklyDeductions();
		}
		
	}
	
	/// <summary>
	/// Resets the timer.
	/// </summary>
	public void resetTimer() {
		this.time_left = this.time_avaiable;
		print("Timer Reset: "+ time_left +" secs");
	}
	
	/// <summary>
	/// Sets the time left.
	/// </summary>
	/// <param name='time_left'>
	/// Time_left.
	/// </param>
	public void setTimeLeft(float time_left) {
		this.time_left = time_left;
	}
	
	/// <summary>
	/// Gets the time left.
	/// </summary>
	/// <returns>
	/// The time left.
	/// </returns>
	public float getTimeLeft() {
		return this.time_left;
	}	
	
	/// <summary>
	/// Pauses the timer.
	/// </summary>
	public void pauseTimer() {
		this.pause = true;	
	}
	
	/// <summary>
	/// Resumes the timer.
	/// </summary>
	public void resumeTimer() {
		this.pause = false;	
	}	
	
}
