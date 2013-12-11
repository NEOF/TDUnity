using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float maxHealth;
	public float currentHealth;
	public float physRes;
	public float mageRes;
	public float poisonRes;
	public float fireRes;
	public float iceRes;
	public float natureRes;
	public float holyRes;
	public float darkRes;
	public TowerManager twrMngr;
	public bool isTower;
	// Use this for initialization
	void Start () {
		if (isTower)
		{
			twrMngr=this.gameObject.GetComponent("TowerManager") as TowerManager;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void getDamage(float dmg)
	{
		if (isTower)
		{
		if (twrMngr.isphysDmg)
		{
			currentHealth-=(dmg-physRes*dmg);
		}
		else if (twrMngr.ismageDmg)
		{
			currentHealth-=(dmg-mageRes*dmg);
		}
		}
		else 
		{
			currentHealth-=(dmg-physRes*dmg);
		}
		
	}
	public void getHeal(float heal)
	{
		currentHealth+=heal;
	}
	public void increaseMax(float buff)
	{
		maxHealth+=buff;
	}
	public void decreaseMax(float buff)
	{
		maxHealth-=buff;
	}
	public bool isDead()
	{
		if (currentHealth<=0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
