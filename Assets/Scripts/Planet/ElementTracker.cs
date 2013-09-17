using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ElementTracker : MonoBehaviour {
	
	// Instance variables.
	
	private int 					total_elements;
	private int						gather_elements;
	
	private List<Element>			elements;
	
	// Use this for initialization
	void Start () {
		
		// Get all elements in the game.
		this.elements = new List<Element>();
		Element[] list = GameObject.FindObjectsOfType(typeof (Element)) as Element[];
		
		// Add elements to the list.
		foreach (Element elem in list) 
			this.elements.Add(elem);
		
		// Set the number of elements that exist in this game.
		this.total_elements = this.elements.Count;
		this.gather_elements = 0;
		
	}
	
	/// <summary>
	/// Sets the number of gathered elements.
	/// </summary>
	/// <param name='count'>
	/// Count.
	/// </param>
	public void setNumberOfGatheredElements(int count) {
		this.gather_elements += count;
	}
	
	/// <summary>
	/// Determine if there are any more elements left in the game that needs to collected by the player.
	/// </summary>
	/// <returns>
	/// The element existance.
	/// </returns>
	public bool areRemaining() {
		return this.total_elements == this.gather_elements;
	}
	
	/// <summary>
	/// Counts all elements.
	/// </summary>
	/// <returns>
	/// The all elements.
	/// </returns>
	public int countAllElements() {
		return this.total_elements;	
	}
	
	/// <summary>
	/// Counts the collected elements.
	/// </summary>
	/// <returns>
	/// The collected elements.
	/// </returns>
	public int countCollectedElements() {
		return this.gather_elements;	
	}
	
}

