// Samuel P.Tobey
// FastForward.cs

using UnityEngine;
using System.Collections;

public class FastForward : MonoBehaviour {

	private bool isFast = false;
	public float speed = 2;
	
	// Implemented for pressing 'f'
	void Update () {
		if(Input.GetKeyDown("f")) {
			ToggleChange();
		}
	}
	
	// Implemented for a button	with a collider
	void OnMouseDown() {
		ToggleChange();
	}
	
	void ToggleChange () {
		if(isFast){
			Time.timeScale = 1;
			isFast = false;
		} else {
			Time.timeScale = speed;
			isFast = true;
		}
	}
}