using UnityEngine;
using System.Collections;

public class UIPause : MonoBehaviour {
	
	// Instance variables.
	static private UIPause			instance;	
	
	public GameObject				pause_screen;
	public Camera					pause_camera;
	
	public tk2dUIItem				btn_resume;
	public tk2dUIItem				btn_main_menu;
	
	public tk2dTextMesh				lbl_week;
	public tk2dTextMesh				lbl_time;
	public tk2dTextMesh				lbl_elements;
	
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
		
		this.elements = GameObject.FindObjectOfType(typeof (ElementTracker)) as ElementTracker;
		
	}
	
	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable() {
		this.btn_resume.OnClick += onResumeClicked;
		this.btn_main_menu.OnClick += onMainMenuClick;
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
		
	}
	
	/// <summary>
	/// Leave this instance.
	/// </summary>
	private void leave() {
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
	
	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable() {
		this.btn_resume.OnClick -= onResumeClicked;
		this.btn_main_menu.OnClick -= onMainMenuClick;
	}	
	
}

