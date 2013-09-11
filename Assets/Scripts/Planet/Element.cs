using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour {
	
	// Instance variables.
	public string				name;
	public int					element_type;
	
	private PlayerScript		player;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		this.player = FindObjectOfType(typeof (PlayerScript)) as PlayerScript;
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		this.gameObject.transform.Rotate(Vector3.up, 5 * Time.deltaTime);
	}
	
	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	private void OnCollisionEnter(Collision col) {
		
		// Add the element to the player's list.
		this.player.addElementToList(this);
		print ("Collected: "+ this.name);		
		
		// Destroy object.
		Destroy(this.gameObject);
		
	}
	
}
