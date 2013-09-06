using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalaxyManager : MonoBehaviour {
	
	// Instance variables.
	static private GalaxyManager		instance;
	
	public Planet						recent_planet;
		
	private GameObject					planet_gameobj;
	private Vector3						loading_pos;
	
	/// <summary>
	/// Gets the instance of the GalaxyManager singleton.
	/// </summary>
	/// <returns>
	/// The instance of this GalaxyManager singleton.
	/// </returns>
	public static GalaxyManager getInstance() {
		
		// Initialize instance for the singleton.
		if (instance == null)
			instance = GameObject.FindObjectOfType(typeof(GalaxyManager)) as GalaxyManager;
		
		return instance;
		
	}
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	/// <summary>
	/// Load the planet level.
	/// </summary>
	/// <param name='name'>
	/// Planet object that will contain the scene to load.
	/// </param>
	public void goToPlanet(Planet p) {
		
		// Remember the planet so that player can exit from that planet.
		this.recent_planet = p;
		
		// Calculate new position that the player will load at when leaving.
		this.loading_pos = this.calculateLoadingPosition();
		
		// Resume timer.
		TimeManager.getInstance().resumeTimer();
		
	}
	
	public Vector3 getLoadingPosition() {
		return loading_pos;
	}
	
	/// <summary>
	/// Load the player in space on the planet they recently visited.
	/// </summary>
	/// <returns>
	/// A vector position that the player will hold.
	/// </returns>
	public Vector3 calculateLoadingPosition() {
		
		//
		this.planet_gameobj = recent_planet.gameObject;
		SphereCollider col = this.planet_gameobj.GetComponent<SphereCollider>();
		
		// Position the player above the planet's north pole.
		float planet_radius = col.radius * this.planet_gameobj.transform.lossyScale.x;
		return new Vector3(this.planet_gameobj.transform.position.x, planet_radius, this.planet_gameobj.transform.position.z);
		
	}
	
}
