using UnityEngine;
using System.Collections;

public class EnemyObject : MonoBehaviour {

	// Instance variables.
	public float					move_speed;
	public int						collide_dmg;
	
	protected ShipStats				ship;
	
	/// <summary>
	/// Initialize this instance.
	/// </summary>
	protected void init() {
		this.ship = GameObject.FindObjectOfType(typeof (ShipStats)) as ShipStats;	
	}
	
	/// <summary>
	/// Gets the collide damage.
	/// </summary>
	/// <returns>
	/// The collide damage.
	/// </returns>
	public int getCollideDamage() {
		return this.collide_dmg;	
	}
	
}
