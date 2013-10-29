﻿using UnityEngine;
using System.Collections;

public class WarriorAttack : MonoBehaviour {
	// Use this for initialization
	public float timeStamp;
	public Animator animator;
	public float damage;
	GameObject Tower;
	
	void Start () {
	timeStamp=0.0f;
	Tower= this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}
	// attack when enemy is inside hit area
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag.Contains("Enemy"))
		{
			Health hp = other.gameObject.GetComponent("Health") as Health;
			animator = Tower.GetComponent<Animator>();
			if (timeStamp<=Time.time)
			{
				hp.getDamage(damage);
				timeStamp=Time.time+2.0f;
				animator.SetBool("Attack",false);		
			}
			// if enemy is dead, destroy enemy object.
			if (hp.isDead())
			{
				Destroy(other.gameObject);
				animator.SetBool("Attack",true);
			}
			
		}
		
	}
}
