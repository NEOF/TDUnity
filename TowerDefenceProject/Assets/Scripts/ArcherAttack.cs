using UnityEngine;
using System.Collections;

public class ArcherAttack : MonoBehaviour {
	public GameObject attackArea;
	public TowerManager twr; 
	public float timeStamp;
	public AttackAreaEnter enemy;
	public GameObject currentTarget;
	public Health hp;
	public int damage;
	// Use this for initialization
	void Start () {
		timeStamp=0.0f;
		damage= 10;
		currentTarget=null;
		twr=this.gameObject.GetComponent("TowerManager") as TowerManager;
		// Check where the tower is located and assign appropriate attack zone for it.
		if(twr.isBotLane && twr.isArcher)
		{
			attackArea = GameObject.Find("ArcherAttackBot");
		}
		if(twr.isTopLane && twr.isArcher)
		{
			attackArea = GameObject.Find("ArcherAttackTop");
		}
		if(twr.isMidLane && twr.isArcher)
		{
			attackArea = GameObject.Find("ArcherAttackMid");
		}
		// getting component from attack zone, so we can get the monster who enterred the zone.
		enemy =attackArea.gameObject.GetComponent("AttackAreaEnter") as AttackAreaEnter;
		
	}
	
	// Update is called once per frame
	void Update () {
	// check if we have target, if we dont, keep checking for target, if we do have, attack this target.
	if (currentTarget!=null)
	{
			Attack();
	}
	else
	{		
			currentTarget=enemy.getEnemy();
			if (currentTarget!=null)
			{
				hp= currentTarget.GetComponent("Health") as Health;
			}
			else{}
		}
		
	
	}
	// method for attacking current target
	void Attack()
	{
		
		if (hp.isDead())
		{
			Destroy(hp.gameObject);
			currentTarget=null;
		}
		if (timeStamp<Time.time)
		{
			hp.getDamage(damage);
			timeStamp=Time.time+2.0f;
		}
		
	}
	
	// getter and setter for damage
	public int getDamageVal()
	{
		return damage;
	}
	public void setDamageVal(int dmg)
	{
		damage=dmg;
	}
	
}
