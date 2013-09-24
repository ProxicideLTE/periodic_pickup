using UnityEngine;
using System.Collections;

public class UIPlanet : MonoBehaviour {
	
	// Instance variables.
	static private UIPlanet			instance;
	
	public GameObject				ui;
	public GameObject				ui_gathered;
	public GameObject				ui_deductions;
	public GameObject				ui_planet_tutorial;
	
	private bool					disable_movement;
	private bool					show_tutorial;
	
	public static UIPlanet getInstance() {	
		
		// Initialize instance for the singleton.
		if (instance == null)
			instance = GameObject.FindObjectOfType(typeof(UIPlanet)) as UIPlanet;
				
		return instance;
		
	}	
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		this.disable_movement = false;
		this.show_tutorial = true;
	}
	
	void Update() {
		
		if (this.show_tutorial) {
			
			this.showPlanetUI();
			this.ui_planet_tutorial.SetActive(true);
			
			if (Input.GetKey(KeyCode.Space)) {
				this.show_tutorial = false;
				this.hidePlanetUI();
				this.ui_planet_tutorial.SetActive(false);
			}
			
		}
		
	}
	
	public void showPlanetUI() {
		this.ui.SetActive(true);
		this.disable_movement = true;
	}
	
	public void hidePlanetUI() {
		this.ui.SetActive(false);
		this.disable_movement = false;
	}
	
	public void showGatheredResources() {
		this.ui_gathered.SetActive(true);
		UIPlanetGatheredElements.getInstance().enableInputs();
	}
	
	public void hideGatheredResources() {
		this.ui_gathered.SetActive(false);
		UIPlanetGatheredElements.getInstance().disableInputs();
	}
	
	public void showWeeklyDeductions() {
		this.ui_deductions.SetActive(true);
		UIPlanetDeductions.getInstance().startAnimation();
		//UIPlanetDeductions.getInstance().deductPlayerElements();
	}
	
	public void hideWeeklyDeductions() {
		this.ui_deductions.SetActive(false);
		UIPlanetDeductions.getInstance().disableInputs();
	}
	
	public bool isMovementDisabled() {
		return this.disable_movement;	
	}
	
}
