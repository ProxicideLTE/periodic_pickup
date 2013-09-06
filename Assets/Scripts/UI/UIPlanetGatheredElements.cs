using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIPlanetGatheredElements : MonoBehaviour {
	
	// Instance variables.
	static private UIPlanetGatheredElements			instance;
	
	public PlayerScript								player;
	public tk2dTextMesh								element_name;
	
	private bool									allow_inputs;
	private int										index;
	private int										total_elements;
	
	private List<Element>							gathered_elements;
	
	public static UIPlanetGatheredElements getInstance() {	
		
		// Initialize instance for the singleton.
		if (instance == null)
			instance = GameObject.FindObjectOfType(typeof(UIPlanetGatheredElements)) as UIPlanetGatheredElements;
				
		return instance;
		
	}		
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		this.index = 0;
		this.allow_inputs = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Cycle through the collected elements.
		if (Input.GetKeyDown(KeyCode.E) && this.allow_inputs) {
			
			int nextIndex = this.index + 1;
			
			// If there are no more elements left in the list.
			if (nextIndex == this.total_elements) {
				
				// Reset.
				this.player.clearGatheredElements();
				this.index = 0;				
				
				UIPlanet.getInstance().hideGatheredResources();
				UIPlanet.getInstance().showWeeklyDeductions();

			}
			
			// Otherwise, display the next element collected.
			else {
				this.index = nextIndex;
				this.showGatheredElements();
			}
			
		}
		
		// Close the collected elements window.
		if (Input.GetButtonDown("Jump") && this.allow_inputs) {
			
			// Reset.
			this.index = 0;
			this.player.clearGatheredElements();
			
			// Show the next window.
			UIPlanet.getInstance().hideGatheredResources();
			UIPlanet.getInstance().showWeeklyDeductions();
			
		}		
		
	}
	
	/// <summary>
	/// Sets the name of the element.
	/// </summary>
	/// <param name='name'>
	/// Name.
	/// </param>
	private void setElementName(string name) {
		this.element_name.text = name;
		this.element_name.Commit();
	}
	
	/// <summary>
	/// Sets the gathered elements during the run.
	/// </summary>
	/// <param name='e'>
	/// E the list of elements that the player gathered.
	/// </param>
	public void setGatheredElements(List<Element> e) {
		this.gathered_elements = e;
		this.total_elements = e.Count;
	}
	
	/// <summary>
	/// Shows the gathered elements.
	/// </summary>
	public void showGatheredElements() {
		
		// Show the first element gathered.
		this.setElementName(this.gathered_elements[this.index].name);
		
		if (this.gathered_elements[this.index].element_type == 0)
			UIPlanetDeductions.getInstance().addEnergyElement();
		
		if (this.gathered_elements[this.index].element_type == 1)
			UIPlanetDeductions.getInstance().addGasElement();
		
		if (this.gathered_elements[this.index].element_type == 2)
			UIPlanetDeductions.getInstance().addMetalElement();
		
		if (this.gathered_elements[this.index].element_type == 3)
			UIPlanetDeductions.getInstance().addMetalloidElement();		
		
	}
	
	public void enableInputs() {
		this.allow_inputs = true;
	}
	
	public void disableInputs() {
		this.allow_inputs = false;
	}	
	
}
