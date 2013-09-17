using UnityEngine;
using System.Collections;

public class SpacePlayerState : PlayerState {
	
	private ShipStats				ship;
	
	public SpacePlayerState(PlayerScript p) {
		this.player = p;
		this.setup();
	}
	
	/// <summary>
	/// Setup this instance.
	/// </summary>
	private void setup() {
		
		this.player.is_exploring = true;
		
		// If the recent planet is the home planet, start the timer.
		TimeManager.getInstance().resumeTimer();
		
		// Hide the planet UI.
		UIPlanet.getInstance().hidePlanetUI();
		
		// Get ship stats from the playerscript class.
		this.ship = this.player.ship;
		
		// Hide the planet model.
		this.player.space_model.SetActive(true);
		this.player.planet_model.SetActive(false);
		
		float planet_radius = this.player.recent_planet.getPlanetRadius() + 0.2f;
		
		// Position.
		this.player.transform.localPosition = new Vector3(0, planet_radius, 0);
		this.player.transform.parent.transform.rotation = Quaternion.identity;
		
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public override void update () {
		
		// Pause game.
		if (Input.GetKeyDown(KeyCode.Escape))
			UIPause.getInstance().pauseGame();		
		
		if (!UIPause.getInstance().isGamePaused()) {
			// As long as the ship is alive, move it.
			if (this.ship.isShipAlive()) {
				this.moveShip();
				if (Input.GetButton("Horizontal"))		this.yawShip();
				if (Input.GetButton("Vertical"))		this.pitchShip();
			}
			
			// Otherwise game over.
			else 
				Application.LoadLevel("game_over");
		}
		
	}
	
	/// <summary>
	/// Moves the ship.
	/// </summary>
	private void moveShip() {
		this.ship.trans.Translate(Vector3.forward * this.ship.speed * Time.deltaTime);
		this.ship.ship_camera.rotation = Quaternion.Slerp(this.ship.ship_camera.rotation, this.ship.trans.rotation, Time.deltaTime * this.ship.camera_recovery_speed);
	}
	
	/// <summary>
	/// Yaws the ship.
	/// </summary>
	private void yawShip() {
		this.ship.trans.Rotate(Vector3.up, Time.deltaTime * this.ship.turn_speed * Input.GetAxis("Horizontal"));
		this.ship.ship_camera.Rotate(Vector3.up, Time.deltaTime * this.ship.turn_speed * Input.GetAxis("Horizontal") * this.ship.camera_turn_speed_factor);
	}
	
	/// <summary>
	/// Pitchs the ship.
	/// </summary>
	private void pitchShip() {
		this.ship.trans.Rotate(Vector3.right, Time.deltaTime * this.ship.turn_speed * Input.GetAxis("Vertical"));
		this.ship.ship_camera.Rotate(Vector3.right, Time.deltaTime * this.ship.turn_speed * Input.GetAxis("Vertical") * this.ship.camera_turn_speed_factor);
	}
	
}
