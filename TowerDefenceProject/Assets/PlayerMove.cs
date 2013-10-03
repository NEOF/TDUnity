using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.A))
		{
			this.transform.position+=new Vector3(30.0f*Time.deltaTime,0.0f,0.0f*Time.deltaTime);
		}
	}
}
