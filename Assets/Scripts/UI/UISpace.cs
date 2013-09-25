using UnityEngine;
using System.Collections;

public class UISpace : MonoBehaviour {
	
	// Instance variables.
	static private UISpace			instance;
	
	public GameObject				health_bar;
	public GameObject				tutorial_window;
	public GameObject[]				tutorial_screens;
	
	private bool					disable_movement;
	private bool					show_tutorial;
	private float					max_width;
	private float					max_height;
	private float					max_depth;
	private int						tutorial_count;
	private int						current_screen;
	
	public static UISpace getInstance() {	
		
		// Initialize instance for the singleton.
		if (instance == null)
			instance = GameObject.FindObjectOfType(typeof(UISpace)) as UISpace;
				
		return instance;
		
	}	
	
	// Use this for initialization
	void Start () {	
		
		// Instantiate variables.
		this.disable_movement = false;
		this.show_tutorial = true;
		this.max_width = this.health_bar.transform.localScale.x;
		this.max_height = this.health_bar.transform.localScale.y;
		this.max_depth = this.health_bar.transform.localScale.z;
		this.tutorial_count = this.tutorial_screens.Length;
		this.current_screen = 0;
		
		// Hide all text.
		foreach (GameObject obj in this.tutorial_screens) {
			obj.SetActive(false);	
		}
		
		this.tutorial_window.SetActive(true);
		this.tutorial_screens[this.current_screen].SetActive(true);			

	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {
		
		if (this.show_tutorial && this.disable_movement) {
			
			if (Input.GetKeyDown(KeyCode.E)) 
				this.showNextTutorialScreen();
			
		}
		
	}
	
	/// <summary>
	/// Shows the next tutorial screen.
	/// </summary>
	private void showNextTutorialScreen() {
		
		int next_screen = this.current_screen + 1;
		
		if (next_screen == this.tutorial_count) 
			this.hideTutorial();	
		
		else {
			this.tutorial_screens[this.current_screen].SetActive(false);
			this.tutorial_screens[next_screen].SetActive(true);
			this.current_screen = next_screen;
		}
		
	}
	
	/// <summary>
	/// Sets the health bar.
	/// </summary>
	/// <param name='percent'>
	/// Percent.
	/// </param>
	public void setHealthBar(float percent) {
		
		float local_percent = this.max_width * percent;
		this.health_bar.transform.localScale = new Vector3(local_percent, this.max_height, this.max_depth);
		
	}
	
	/// <summary>
	/// Hides the tutorial window.
	/// </summary>
	public void hideTutorial() {
		this.show_tutorial = false;
		this.disable_movement = false;
		this.tutorial_window.SetActive(false);
		this.current_screen = 0;
	}
	
	/// <summary>
	/// Disables the movement.
	/// </summary>
	public void disableMovement() {
		 this.disable_movement = true;
	}
	
	/// <summary>
	/// Determine if the movement disabled.
	/// </summary>
	public bool isMovementDisabled() {
		return this.disable_movement;
	}
	
}
