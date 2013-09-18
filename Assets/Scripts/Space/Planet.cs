using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	
	// Instance variables.
	public string				name;
	
	public AudioClip			bgm;
	public SphereCollider		planet_collider;
	
	private PlayerScript		player;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		this.player = FindObjectOfType(typeof (PlayerScript)) as PlayerScript;
	}
	
	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	void OnCollisionEnter(Collision col) {
		
		// If the player's ship collided, enter the planet.
		if (col.gameObject.name == "Ship") {
			
			// Set this planet to be the most recently visited planet.
			this.player.recent_planet = this;
			this.player.recent_planet_collider = this.planet_collider;
			
			// Switch state to allow the player to enter the planet.
			this.player.changeState(new PlanetPlayerState(this.player));
			
		}
		
	}
	
	/// <summary>
	/// Calculates this planet's radius.
	/// </summary>
	/// <returns>
	/// The planet radius.
	/// </returns>
	public float getPlanetRadius() {
		return this.planet_collider.radius * this.transform.lossyScale.x;
	}
	
}
