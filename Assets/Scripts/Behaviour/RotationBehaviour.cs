using UnityEngine;
using System.Collections;

public class RotationBehaviour : MonoBehaviour {

	public float				turn_speed;
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Rotate(Vector3.up, this.turn_speed * Time.deltaTime);
	}
	
}
