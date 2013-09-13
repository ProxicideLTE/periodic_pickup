using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {
	
	public GameObject				centroid_planet;
	public GameObject				planet_model;
	public GameObject				space_model;
	
	public Planet					recent_planet;
	public ShipStats				ship;
	public SphereCollider			recent_planet_collider;
	
	private int						week_num;
	
	private PlayerState				state;
	private List<Element>			gathered_elements;
	
	// Use this for initialization
	void Start () {
		
		// Instantiate variables.
		this.week_num = 0;
		this.state = new PlanetPlayerState(this);
		this.gathered_elements = new List<Element>();
		
		// Hide UI.
		UIPlanet.getInstance().hidePlanetUI();
		
	}
	
	// Update is called once per frame
	void Update () {
		this.state.update();
	}
	
	/// <summary>
	/// Changes the state.
	/// </summary>
	/// <param name='state'>
	/// State for the player to switch to.
	/// </param>
	public void changeState(PlayerState state) {
		this.state = state;	
	}
	
	/// <summary>
	/// Adds the element to list.
	/// </summary>
	/// <param name='e'>
	/// E the element that will be added to the list.
	/// </param>
	public void addElementToList(Element e) {
		this.gathered_elements.Add(e);	
	}
	
	/// <summary>
	/// Clears the gathered elements list.
	/// </summary>
	public void clearGatheredElements() {
		this.gathered_elements.Clear();
	}
	
	public int countGatheredElements() {
		return this.gathered_elements.Count;
	}
	
	public List<Element> getGatheredElements() {
		return this.gathered_elements;	
	}
	
	public void incrementWeekCount() {
		this.week_num++;
	}
	
}
