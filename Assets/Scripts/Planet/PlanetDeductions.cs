using UnityEngine;
using System.Collections;

public class PlanetDeductions : MonoBehaviour {
	
	// Instance variables.
	static private PlanetDeductions			instance;	
	
	public int			enegry_amount;
	public int			gas_amount;
	public int			metal_amount;
	public int			metalloid_amount;
	
	public int			deduct_enegry_amount;
	public int			deduct_gas_amount;
	public int			deduct_metal_amount;
	public int			deduct_metalloid_amount;	

	public static PlanetDeductions getInstance() {	
		
		// Initialize instance for the singleton.
		if (instance == null)
			instance = GameObject.FindObjectOfType(typeof(PlanetDeductions)) as PlanetDeductions;
				
		return instance;
		
	}			
	
	void Start() {
		DontDestroyOnLoad(this);
	}
	
	/// <summary>
	/// Deduct the player's elements.
	/// </summary>
	public void deduct() {
		
		// Deduct elements.
		this.enegry_amount -= this.deduct_enegry_amount;
		this.gas_amount -= this.deduct_gas_amount;
		this.metal_amount -= this.deduct_metal_amount;
		this.metalloid_amount -= this.deduct_metalloid_amount;
		
		// Check to see if there is any elements left.
		if (this.enegry_amount <= 0 || this.gas_amount <= 0 || this.metal_amount <= 0 || this.metalloid_amount <= 0)
			Application.LoadLevel("game_over");
		
	}
	
	/// <summary>
	/// Adds the energy element.
	/// </summary>
	public void addEnergyElement() {
		this.enegry_amount ++;
	}
	
	/// <summary>
	/// Adds the gas element.
	/// </summary>
	public void addGasElement() {
		this.gas_amount ++;
	}
	
	/// <summary>
	/// Adds the metal element.
	/// </summary>
	public void addMetalElement() {
		this.metal_amount ++;	
	}
	
	/// <summary>
	/// Adds the metalloid element.
	/// </summary>
	public void addMetalloidElement() {
		this.metalloid_amount ++;	
	}	
	
}
