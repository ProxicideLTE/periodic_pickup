using UnityEngine;
using System.Collections;

public class Asteroid : EnemyObject {
	
	// Instance variables.			
	
	// Use this for initialization
	void Start () {
		this.init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	void OnCollisionEnter(Collision col) {
		
		// Detect if the ship collided with this asteroid.
		if (col.gameObject.name == "Ship") {
			this.ship.applyDamage(this.collide_dmg);
			audio.PlayOneShot(this.collision_sound);
			Destroy(this.gameObject);
		}

	}
	
}
