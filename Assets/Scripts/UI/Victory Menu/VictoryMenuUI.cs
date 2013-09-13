using UnityEngine;
using System.Collections;

public class VictoryMenuUI : MonoBehaviour {
	
	// Instance variables.
	public tk2dUIItem			btn_main_menu;
	
	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable() {
		this.btn_main_menu.OnClick += onMainMenuClick;
	}
	
	/// <summary>
	/// On the start game click.
	/// </summary>
	void onMainMenuClick() {
		Application.LoadLevel("main_menu");
	}
	
	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable() {
		this.btn_main_menu.OnClick -= onMainMenuClick;
	}	
	
}
