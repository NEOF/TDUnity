// Samuel P. Tobey
// SpellsMenu.cs

using UnityEngine;
using System.Collections;

public class SpellsMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		UpdateSpells();
	}
	
	void UpdateSpells() {
		GUILayout.BeginArea(new Rect((Screen.width * 0.9f)-30,(Screen.height * 0.9f)-100, 100, 200));
		
		if(GUILayout.Button("Spell 1")) {
			
		}
		if(GUILayout.Button("Spell 2")) {
			
		}
		if(GUILayout.Button("Spell 2")) {
			
		}
		
		GUILayout.EndArea();
	}
}
