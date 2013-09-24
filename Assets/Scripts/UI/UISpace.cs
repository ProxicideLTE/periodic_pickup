using UnityEngine;
using System.Collections;

public class UISpace : MonoBehaviour {
	
	// Instance variables.
	public GameObject			health_bar;
	public GameObject			tutorial_window;
	public GameObject[]			tutorial_screens;
	
	private bool				show_tutorial;
	private float				max_width;
	private float				max_height;
	private float				max_depth;
	private int					tutorial_count;
	
	// Use this for initialization
	void Start () {
		
		// Instantiate variables.
		this.show_tutorial = true;
		this.max_width = this.health_bar.transform.localScale.x;
		this.max_height = this.health_bar.transform.localScale.y;
		this.max_depth = this.health_bar.transform.localScale.z;
		this.tutorial_count = this.tutorial_screens.Length;
		
	}
	
	void Update() {
			
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
	
}
