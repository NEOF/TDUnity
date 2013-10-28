// Samuel P. Tobey
// PauseMenu.cs

using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GUISkin skin;
	private bool isPaused = false;
	// Enter in the current level for Restart to work
	public int currentLevel;
	//private float previousSpeed = ???;
	
	void OnMouseUp() {
		isPaused = !isPaused;
		if(isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
	
	void Update() {
		if(Input.GetKeyDown("p")) {
			isPaused = !isPaused;
			if(isPaused) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}	
		}
		
		// This will NOT guarantee override other
		//  actions such as FastForward.  
		if(isPaused) {
			Time.timeScale = 0;
		}
	}
	
	void OnGUI() {
		if(isPaused) {
			Pause();
		}
	}
		
	void Pause() {
		GUILayout.BeginArea(new Rect((Screen.width * 0.5f)-50,(Screen.height * 0.5f)-100, 100, 200));
		
		// Unpause
		if(GUILayout.Button("Resume")) {
			Time.timeScale = 1;	
			isPaused = false;
		}
		
		// Loads the current level from scratch 
		if(GUILayout.Button("Restart")) {
			Time.timeScale = 1;
			isPaused = false;
			Application.LoadLevel(currentLevel);
		}
		
		/* No options yet
		if(GUILayout.Button("Options")) {
			
		}
		*/
		
		// Main Menu must be level '0'
		if(GUILayout.Button("Main Menu")) {
			Time.timeScale = 1;
			isPaused = false;
			Application.LoadLevel(0);
		}
		
		GUILayout.EndArea();
	}
}
