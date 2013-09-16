using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {
	
	// Instance variables.
	public tk2dUIItem			btn_start;
	public tk2dUIItem			btn_instructions;
	
	public GameObject			instructions_menu;
	
	private bool				toggle_instructions;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {
		this.toggle_instructions = false;
		this.instructions_menu.SetActive(false);
	}
	
	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable() {
		this.btn_start.OnClick += onStartGameClick;
		this.btn_instructions.OnClick += onInstructionsClick;
	}
	
	/// <summary>
	/// On the start game click.
	/// </summary>
	void onStartGameClick() {
		Application.LoadLevel("game");
	}
	
	/// <summary>
	/// On the instructions click.
	/// </summary>
	void onInstructionsClick() {
		if (!this.toggle_instructions) {
			this.instructions_menu.SetActive(true);
			this.toggle_instructions = true;	
		}
		
		else {
			this.instructions_menu.SetActive(false);
			this.toggle_instructions = false;
		}
	}
	
	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable() {
		this.btn_start.OnClick -= onStartGameClick;
		this.btn_instructions.OnClick += onInstructionsClick;
	}		
	
}
