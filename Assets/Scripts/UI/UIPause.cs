using UnityEngine;
using System.Collections;

public class UIPause : MonoBehaviour {
	
	// Instance variables.
	static private UIPause			instance;	
	
	public AudioClip				sfx_popup;
	
	public GameObject				pause_screen;
	public GameObject				win_controls;
	public GameObject				win_pause;
	public Camera					pause_camera;
	
	public tk2dUIItem				btn_resume;
	public tk2dUIItem				btn_main_menu;
	public tk2dUIItem				btn_controls;
	
	public tk2dTextMesh				lbl_week;
	public tk2dTextMesh				lbl_time;
	public tk2dTextMesh				lbl_elements;
	public tk2dTextMesh				lbl_energy;
	public tk2dTextMesh				lbl_gas;
	public tk2dTextMesh				lbl_metal;
	public tk2dTextMesh				lbl_metalloid;		
	
	private ElementTracker			elements;
	
	private bool					is_pause;
	
	public static UIPause getInstance() {	
		
		// Initialize instance for the singleton.
		if (instance == null)
			instance = GameObject.FindObjectOfType(typeof(UIPause)) as UIPause;
				
		return instance;
		
	}	
	
	/// <summary>
	/// Setup this instance.
	/// </summary>
	void Start() {
		this.is_pause = false;
		this.pause_camera.enabled = false;
		this.pause_screen.SetActive(false);
		this.win_controls.SetActive(false);
		this.elements = GameObject.FindObjectOfType(typeof (ElementTracker)) as ElementTracker;
		
	}
	
	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable() {
		this.btn_resume.OnClick += onResumeClicked;
		this.btn_main_menu.OnClick += onMainMenuClick;
		this.btn_controls.OnClick += onControlsClick;
	}
	
	/// <summary>
	/// Pauses the game.
	/// </summary>
	public void pauseGame() {
		if (!is_pause)		this.enter();
		else 				this.leave();
	}
	
	/// <summary>
	/// Enter this instance.
	/// </summary>
	private void enter() {
		audio.PlayOneShot(this.sfx_popup);
		this.pause_screen.SetActive(true);
		this.is_pause = true;
		this.pause_camera.enabled = true;
		TimeManager.getInstance().pauseTimer();
		this.setLabels();
	}
	
	/// <summary>
	/// Sets the labels for the pause menu.
	/// </summary>
	private void setLabels() {
		
		// Set the text for all the labels.
		this.lbl_week.text = "Week: "+ TimeManager.getInstance().getWeekCount();
		this.lbl_week.Commit();
		
		this.lbl_time.text = "Time Remaining: "+ TimeManager.getInstance().getTimeLeft() +"s";
		this.lbl_time.Commit();
		
		this.lbl_elements.text = "Elements Found: "+ this.elements.countCollectedElements() + "/" +this.elements.countAllElements();
		this.lbl_elements.Commit();
		
		this.lbl_energy.text = "Energy Sources: "+ UIPlanetDeductions.getInstance().enegry_amount;
		this.lbl_energy.Commit();
		
		this.lbl_gas.text = "Gas Units: "+ UIPlanetDeductions.getInstance().gas_amount;
		this.lbl_gas.Commit();
		
		this.lbl_metal.text = "Metals: "+ UIPlanetDeductions.getInstance().metal_amount;
		this.lbl_metal.Commit();
		
		this.lbl_metalloid.text = "Metalloids: "+ UIPlanetDeductions.getInstance().metalloid_amount;
		this.lbl_metalloid.Commit();		
		
	}
	
	/// <summary>
	/// Leave this instance.
	/// </summary>
	private void leave() {
		this.pause_screen.SetActive(false);
		this.win_controls.SetActive(false);
		this.win_pause.SetActive(true);
		this.is_pause = false;
		this.pause_camera.enabled = false;
		TimeManager.getInstance().resumeTimer();
	}
	
	/// <summary>
	/// Is the game paused.
	/// </summary>
	/// <returns>
	/// The game paused.
	/// </returns>
	public bool isGamePaused() {
		return this.is_pause;
	}
		
// Event Handlers.	
	
	/// <summary>
	/// On the resume button clicked.
	/// </summary>
	void onResumeClicked() {
		this.leave();
	}
	
	/// <summary>
	/// On the main menu button click.
	/// </summary>
	void onMainMenuClick() {
		Application.LoadLevel("main_menu");	
	}
	
	void onControlsClick() {
		this.win_controls.SetActive(true);
		this.win_pause.SetActive(false);
	}
	
	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable() {
		this.btn_resume.OnClick -= onResumeClicked;
		this.btn_main_menu.OnClick -= onMainMenuClick;
		this.btn_controls.OnClick -= onControlsClick;
	}	
	
}

