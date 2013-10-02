using UnityEngine;
using System.Collections;

public class WarriorAttack : MonoBehaviour {
	// Use this for initialization
	public float timeStamp;
	
	void Start () {
	timeStamp=0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name.Contains("Enemy"))
		{
			Health hp = other.gameObject.GetComponent("Health") as Health;
			if (timeStamp<=Time.time)
			{
				hp.getDamage(10);
				timeStamp=Time.time+2.0f;
			}
			if (hp.isDead())
			{
				Destroy(other.gameObject);
			}
			
		}
		
	}
}
