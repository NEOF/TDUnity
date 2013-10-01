using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int maxHealth;
	public int currentHealth;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void getDamage(int dmg)
	{
		currentHealth-=dmg;
	}
	public void getHeal(int heal)
	{
		currentHealth+=heal;
	}
	public void increaseMax(int buff)
	{
		maxHealth+=buff;
	}
	public void decreaseMax(int buff)
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
