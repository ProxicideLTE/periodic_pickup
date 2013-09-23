using UnityEngine;
using System.Collections;

public class ShipStats : MonoBehaviour {

	public float 			speed;
	public float			turn_speed;
	public float			camera_turn_speed_factor;
	public float			camera_recovery_speed;
	
	public int				hp;
	
	public Transform		trans;
	public Transform		ship_camera;
	public UISpace			ui;
	
	private bool			is_alive;
	
	private int				max_hp;
	
	void Start() {
		DontDestroyOnLoad(this);
		this.is_alive = true;
		this.max_hp = this.hp;
	}
	
	/// <summary>
	/// Applies the damage.
	/// </summary>
	/// <param name='dmg'>
	/// Dmg.
	/// </param>/
	public void applyDamage(int dmg) {
		
		// Apply damage.
		this.hp -= dmg;
		
		// Check if the player is still alive.
		if (this.hp <= 0) {
			this.is_alive = false;	
		}
		
		// Otherwise update the health bar.
		else {
			this.ui.setHealthBar((float)this.hp/(float)this.max_hp);
		}
		
	}
	
	/// <summary>
	/// Determine if the ship is still alive.
	/// </summary>
	/// <returns>
	/// Boolean if the ship is alive.
	/// </returns>
	public bool isShipAlive() {
		return this.is_alive;	
	}
	
}
