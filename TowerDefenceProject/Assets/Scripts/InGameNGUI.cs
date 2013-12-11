using UnityEngine;
using System.Collections;

public class InGameNGUI : MonoBehaviour {
	
	// NGUI items
	public bool buildPanelOpen = false;
	/**
	public TweenPosition buildPanelTweener;
	public TweenRotation buildPanelArrowTweener;
	**/
	
	// Placement Plane Items
	public Transform placementPlanesRoot;
	public Material hoverMaterial;
	public LayerMask placementLayerMask;
	private Material originalMaterial;
	private GameObject lastHitObject;
	
	// Build Selection Items
	/**
	public Color onColor;
	public Color offColor;
	**/
	public GameObject[] allStructures;
	public UISlicedSprite[] buildBtnGraphics;
	private int structureIndex = 0;
	
	
	void Start () {
		// Refresh the GUI and reset the structureIndex to 0
		structureIndex = 0;
		//UpdateGUI();
	}

	
	void Update () {
		if(buildPanelOpen) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 1000, placementLayerMask)) {
				if(lastHitObject) {
					lastHitObject.renderer.material = originalMaterial;
				}
			lastHitObject = hit.collider.gameObject;
			originalMaterial = lastHitObject.renderer.material;
			lastHitObject.renderer.material = hoverMaterial;
			} else {
				if(lastHitObject) {
						lastHitObject.renderer.material = originalMaterial;
						lastHitObject = null;
				}
			}
// Could Cause Problems: GetButtonDown(string BUTTONNAME) '0' is left mouse button. ???
			if(Input.GetMouseButtonDown(0) && lastHitObject) {
				if(lastHitObject.tag == "PlacementPlane_Vacant") {
					/**
					Transform t = Instantiate(allStructures[structureIndex], 
						lastHitObject.transform.position, Quaternion.identity);
					GameObject newStructure = t.gameObject;
					**/
					// Use to cause the tower to face random direction:
					//newStructure.transform.localEulerAngles.y = (Random.Range(0, 360));
					lastHitObject.tag = "PlacementPlane_Occupied";
				}
			}
		}
	}
	
/**
	void UpdateGUI() {
		foreach(UISlicedSprite theBtnGraphic in buildBtnGraphics)
		{
			theBtnGraphic.color = offColor;
		}
		
		// Set build button to "on"
		buildBtnGraphics[structureIndex].color = onColor;
	}
**/
	
	void toggleBuildPanel() {
		if(buildPanelOpen) {
			foreach(Transform thePlane in placementPlanesRoot) {
				thePlane.gameObject.renderer.enabled = false;
			}
			buildPanelOpen = false;
			/**
			buildPanelTweener.Play(false);
			buildPanelArrowTweener.Play(false);
			**/
		} else {
			foreach(Transform thePlane in placementPlanesRoot) {
				thePlane.gameObject.renderer.enabled = true;
			}
			buildPanelOpen = true;
			/**
			buildPanelTweener.Play(true);
			buildPanelArrowTweener.Play(true);
			**/
		}
	}
	
	void SetBuildChoice(GameObject btnObj) {
		string btnName = btnObj.name;
		if(btnName == "WarriorTower") {
			structureIndex = 0;
		} else if(btnName == "ArcherTower") {
			structureIndex = 1;
		} else if(btnName == "MageTower") {
			structureIndex = 2;
		}
	}
}
