using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIPlanetGatheredElements : MonoBehaviour {
	
	// Instance variables.
	static private UIPlanetGatheredElements			instance;
	
	public ElementTracker							element_mgr;
	public GameObject								cube_mesh;
	public PlayerScript								player;
	public tk2dTextMesh								element_name;
		
	private bool									allow_inputs;
	private int										index;
	private int										total_elements;
	
	private List<Element>							gathered_elements;
		
	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <returns>
	/// The instance.
	/// </returns>
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
			if (nextIndex == this.total_elements) 
				this.showNextScreen();
			
			// Otherwise, display the next element collected.
			else {
				this.index = nextIndex;
				this.showGatheredElements();
			}
			
		}
		
		// Close the collected elements window.
		if (Input.GetButtonDown("Jump") && this.allow_inputs) 
			this.showNextScreen();
		
	}
	
	/// <summary>
	/// Shows the next screen.
	/// </summary>
	private void showNextScreen() {
						
		// If all elements have been gathered, the game is over.
		if (this.element_mgr.areRemaining()) 
			Application.LoadLevel("victory_menu");
		
		// Otherwise, show the deduction screen.
		else {
			
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
		this.element_mgr.setNumberOfGatheredElements(this.total_elements);	
	}
	
	/// <summary>
	/// Shows the gathered elements.
	/// </summary>
	public void showGatheredElements() {
		
		// Show the first element gathered.
		this.setElementName(this.gathered_elements[this.index].name);
		this.cube_mesh.renderer.material = this.gathered_elements[this.index].getElementMaterial();
		
		// Determine the element type.
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
