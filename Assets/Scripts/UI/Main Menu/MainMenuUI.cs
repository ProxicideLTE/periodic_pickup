using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {
	
	// Instance variables.
	public tk2dUIItem			btn_start;
	
	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable() {
		this.btn_start.OnClick += onStartGameClick;
	}
	
	/// <summary>
	/// On the start game click.
	/// </summary>
	void onStartGameClick() {
		Application.LoadLevel("game");
	}
	
	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable() {
		this.btn_start.OnClick -= onStartGameClick;
	}		
	
}
