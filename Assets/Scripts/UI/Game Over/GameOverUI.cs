using UnityEngine;
using System.Collections;

public class GameOverUI : MonoBehaviour {

	public tk2dUIItem			btn_main_menu;
	
	void OnEnable() {
		this.btn_main_menu.OnClick += onMainMenuClick;
	}	
		
	void onMainMenuClick() {
		Application.LoadLevel("main_menu");
	}
	
	void OnDisable() {
		this.btn_main_menu.OnClick -= onMainMenuClick;
	}	
	
}
