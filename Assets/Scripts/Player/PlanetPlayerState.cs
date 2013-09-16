using UnityEngine;
using System.Collections;

public class PlanetPlayerState : PlayerState {
	
	private float					movement_speed;
	private float					turn_speed;
	private float					planet_radius;
	private float					walk_path;
	
	public PlanetPlayerState(PlayerScript p) {
		this.player = p;
		this.setup();
	}
	
	/// <summary>
	/// Setup this instance.
	/// </summary>
	private void setup() {
		
		Debug.Log("Entering: "+ this.player.recent_planet.name);
		
		// Initialize variables.
		this.movement_speed = 15;
		this.turn_speed = 2.5f;
		this.planet_radius = this.player.recent_planet.getPlanetRadius();
		this.walk_path = 0;
		
		this.player.space_model.SetActive(false);
		this.player.planet_model.SetActive(true);
				
		// Set position and orientation.
		this.player.centroid_planet.transform.position = this.player.recent_planet.transform.position;
		this.player.transform.localPosition = new Vector3(0,this.planet_radius,0);
		this.player.transform.parent.transform.rotation = Quaternion.identity;
		this.player.planet_model.transform.localRotation = Quaternion.identity;
		
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public override void update () {
		this.updateControls();
		this.player.planet_model.transform.localRotation = Quaternion.identity;
	}
	
	/// <summary>
	/// Updates the controls.
	/// </summary>
	private void updateControls() {
		
		// Pause game.
		if (Input.GetKeyDown(KeyCode.Escape))
			UIPause.getInstance().pauseGame();
		
		if (!UIPause.getInstance().isGamePaused()) {
		
			this.walk_path = 0;
			
			// Translating the player around the planet.
			if (Input.GetButton("Vertical") && !UIPlanet.getInstance().isMovementDisabled()) {
				this.walk_path = this.movement_speed / this.planet_radius;
				this.player.centroid_planet.transform.Rotate(walk_path * Time.deltaTime * Input.GetAxis("Vertical"), 0, 0);
			}
			
			if (Input.GetButton("Horizontal") && !UIPlanet.getInstance().isMovementDisabled()) {
				this.walk_path = this.movement_speed / this.planet_radius;
				this.player.centroid_planet.transform.Rotate(0, 0, walk_path * Time.deltaTime * -Input.GetAxis("Horizontal"));	
			}
	
			// Turn the player.
			if(Input.GetAxis("Mouse X") < 0 && !UIPlanet.getInstance().isMovementDisabled()) 
	    		this.player.centroid_planet.transform.Rotate(0, -this.turn_speed, 0);
			
			if(Input.GetAxis("Mouse X") > 0 && !UIPlanet.getInstance().isMovementDisabled()) 
	    		this.player.centroid_planet.transform.Rotate(0, this.turn_speed, 0);				
			
			// Exit the planet.
			if(Input.GetButtonDown("Jump") && !UIPlanet.getInstance().isMovementDisabled()) 
				this.player.changeState(new SpacePlayerState(this.player));
			
		}
		
	}
	
}
