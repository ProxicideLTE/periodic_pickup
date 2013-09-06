using UnityEngine;
using System.Collections;

public class UIPlanetDeductions : MonoBehaviour {
	
	// Instance variables.
	static private UIPlanetDeductions			instance;

	private bool								allow_inputs;
	private bool								should_animate;
	
	private float								delay = 0.5f;
	private float								time;
	
	private int									energy_count, gas_count, metal_count, metalloid_count;
	
	public int									enegry_amount;
	public int									gas_amount;
	public int									metal_amount;
	public int									metalloid_amount;
	public int									deduct_enegry_amount;
	public int									deduct_gas_amount;
	public int									deduct_metal_amount;
	public int									deduct_metalloid_amount;	

	public tk2dTextMesh							tbx_energy;
	public tk2dTextMesh							tbx_gas;
	public tk2dTextMesh							tbx_metal;
	public tk2dTextMesh							tbx_metalloid;	
	
	public static UIPlanetDeductions getInstance() {	
		
		// Initialize instance for the singleton.
		if (instance == null)
			instance = GameObject.FindObjectOfType(typeof(UIPlanetDeductions)) as UIPlanetDeductions;
				
		return instance;
		
	}	
	
	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad(this);
		
		// Instantiate variables.
		this.allow_inputs = false;
		this.should_animate = false;
		this.time = 0;
		
		this.energy_count = this.deduct_enegry_amount;
		this.gas_count = this.deduct_gas_amount;
		this.metal_count = this.deduct_metal_amount;
		this.metalloid_count = this.deduct_metalloid_amount;
		
	}
	
	void Update() {
		
		if (this.should_animate) {
			this.animate();
		}
		
		// Exit this window.
		if (Input.GetKeyDown(KeyCode.E) && this.allow_inputs) {
			
			// Reset counters.
			this.energy_count = this.deduct_enegry_amount;
			this.gas_count = this.deduct_gas_amount;
			this.metal_count = this.deduct_metal_amount;
			this.metalloid_count = this.deduct_metalloid_amount;			
			
			// Hide the UI window.
			UIPlanet.getInstance().hideWeeklyDeductions();
			UIPlanet.getInstance().hidePlanetUI();
			
		}
		
	}
	
	public void animate() {
		
		this.time += Time.deltaTime;
		
		if (this.time >= this.delay) {
						
			if (this.energy_count > 0) {
				this.enegry_amount --; 		this.energy_count --;
				this.tbx_energy.text = this.enegry_amount+ "";
				this.tbx_energy.Commit();
			}
		
			if (this.gas_count > 0) {
				this.gas_amount --; 		this.gas_count --;
				this.tbx_gas.text = this.gas_amount+ "";
				this.tbx_gas.Commit();
			}
			
			if (this.metal_count > 0) {
				this.metal_amount --; 		this.metal_count --;
				this.tbx_metal.text = this.metal_amount+ "";
				this.tbx_metal.Commit();
			}
			
			if (this.metalloid_count > 0) {
				this.metalloid_amount --; 	this.metalloid_count --;
				this.tbx_metalloid.text = this.metalloid_amount+ "";
				this.tbx_metalloid.Commit();
			}
			
			// Check to see if there is any elements left.
			if (this.enegry_amount <= 0 || this.gas_amount <= 0 || this.metal_amount <= 0 || this.metalloid_amount <= 0)
				Application.LoadLevel("game_over");				
			
			else if (this.metalloid_count == 0 && this.metal_count == 0 && this.gas_count == 0 && this.energy_count == 0) {
				this.should_animate = false;
				this.enableInputs();
			}
			
			this.time = 0;
		}
	}
	
	/// <summary>
	/// Starts the animation.
	/// </summary>
	public void startAnimation() {
		this.should_animate = true;	
	}
	
	/// <summary>
	/// Enables the inputs.
	/// </summary>
	public void enableInputs() {
		this.allow_inputs = true;
	}
	
	/// <summary>
	/// Disables the inputs.
	/// </summary>
	public void disableInputs() {
		this.allow_inputs = false;
	}
		
	/// <summary>
	/// Adds the energy element.
	/// </summary>
	public void addEnergyElement() {
		this.enegry_amount ++;
		this.tbx_energy.text = this.enegry_amount +"";
		this.tbx_energy.Commit();
	}
	
	/// <summary>
	/// Adds the gas element.
	/// </summary>
	public void addGasElement() {
		this.gas_amount ++;
		this.tbx_gas.text = this.gas_amount +"";
		this.tbx_gas.Commit();		
	}
	
	/// <summary>
	/// Adds the metal element.
	/// </summary>
	public void addMetalElement() {
		this.metal_amount ++;
		this.tbx_metal.text = this.metal_amount +"";
		this.tbx_metal.Commit();		
	}
	
	/// <summary>
	/// Adds the metalloid element.
	/// </summary>
	public void addMetalloidElement() {
		this.metalloid_amount ++;
		this.tbx_metalloid.text = this.metalloid_amount +"";
		this.tbx_metalloid.Commit();		
	}		
	
}
