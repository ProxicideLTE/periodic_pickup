using UnityEngine;
using System.Collections;

public class UIPlanetPauseMenu : MonoBehaviour {
	
	public tk2dUIItem			btn_resume;
	public tk2dUIItem			btn_main_menu;
	public tk2dUIItem			btn_exit;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable() {
		this.btn_resume.OnClick += onResumeClick;
	}	
	

	
	void onResumeClick() {
		print ("Resume Game");
	}
	
	void OnDisable() {
		this.btn_resume.OnClick -= onResumeClick;
	}
	
}
