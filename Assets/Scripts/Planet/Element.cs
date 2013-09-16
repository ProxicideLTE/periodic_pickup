using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour {
	
	// Instance variables.
	public string				name;
	public int					element_type;
	
	private string[]			elemental_type;
	
	private Material			material;
	private PlayerScript		player;
		
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		this.player = FindObjectOfType(typeof (PlayerScript)) as PlayerScript;
		this.material = this.gameObject.renderer.material;
		
		this.elemental_type = new string[] {"Energy Source", "Gas", "Metal", "Metalloid"};
		
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
	
	/// <summary>
	/// Gets this element's material.
	/// </summary>
	/// <returns>
	/// The element material.
	/// </returns>
	public Material getElementMaterial() {
		return this.material;	
	}
	
	/// <summary>
	/// Gets the type of the element.
	/// </summary>
	/// <returns>
	/// The element type.
	/// </returns>
	public string getElementType() {
		return this.elemental_type[this.element_type];
	}
	
}
