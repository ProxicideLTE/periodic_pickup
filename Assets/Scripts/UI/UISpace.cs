using UnityEngine;
using System.Collections;

public class UISpace : MonoBehaviour {
	
	// Instance variables.
	public GameObject			health_bar;
	
	private float				max_width;
	private float				max_height;
	private float				max_depth;
	
	// Use this for initialization
	void Start () {
		
		// Instantiate variables.
		this.max_width = this.health_bar.transform.localScale.x;
		this.max_height = this.health_bar.transform.localScale.y;
		this.max_depth = this.health_bar.transform.localScale.z;
		
	}
	
	
	public void setHealthBar(float percent) {
		
		float local_percent = this.max_width * percent;
		this.health_bar.transform.localScale = new Vector3(local_percent, this.max_height, this.max_depth);
		
	}
	
}
