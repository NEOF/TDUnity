using UnityEngine;
using System.Collections;

public class AttackAreaEnter : MonoBehaviour {
	 public GameObject enemy;
	// Use this for initialization
	void Start () {
		enemy=null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//checking for collison
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name.Contains("Enemy"))
		{
			enemy=other.gameObject;
		}
	}
	// return enemy which stays in collider
	public GameObject getEnemy()
	{
		return enemy;
	}
}
