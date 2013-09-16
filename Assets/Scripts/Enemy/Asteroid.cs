using UnityEngine;
using System.Collections;

public class Asteroid : EnemyObject {
	
	// Instance variables.
	private Vector3				direction;
	
	// Use this for initialization
	void Start () {
		
		// Go to the super class for more initialization.
		this.init();
		
		// Set a random direction for this asteroid to move to.
		int type = Random.Range(0,3);
		
		if (type == 0)
			this.direction = Vector3.forward;
		
		else if (type == 1)
			this.direction = Vector3.up;
		
		else if (type == 2)
			this.direction = Vector3.down;
		
		else if (type == 3)
			this.direction = Vector3.back;		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!UIPause.getInstance().isGamePaused())
			this.transform.Translate(this.direction * this.move_speed * Time.deltaTime);
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
			Destroy(this.gameObject);
		}

	}
	
}
