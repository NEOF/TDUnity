using UnityEngine;
using System.Collections;

public class WarriorAttack : MonoBehaviour {
	// Use this for initialization
	public float timeStamp;
	public Animator animator;
	public float damage;
	GameObject Tower;
	public TowerManager towerManager;
	public GameObject attackAreaMelee;
	public GameObject attackAreaRanged;
	public GameObject enemy;
	public AttackAreaEnter attackAreaRangedEnter;
	public AttackAreaEnter attackAreaMeleeEnter;
	public Health hp;
	
	void Start () {
	timeStamp=0.0f;
	towerManager=this.gameObject.GetComponent("TowerManager") as TowerManager;
	attackAreaMelee=this.transform.GetChild(3).gameObject;
	attackAreaMeleeEnter= attackAreaMelee.GetComponent("AttackAreaEnter") as AttackAreaEnter;
	
	}
	
	// Update is called once per frame
	void Update () {
		// attack when enemy is inside hit area
		if (this.towerManager.isMode1 && !this.towerManager.isMode2 && !this.towerManager.isMode3)
		{
			basicMelee();
		}
		if (!this.towerManager.isMode1 && this.towerManager.isMode2 && !this.towerManager.isMode3)
		{
			basicRanged();
		}
	}
	// basic melee attack which just deals damage and runs animation. простая атака ближнего боя которая наносит урон и проигрывает анимацию
	public void basicMelee()
	{
		this.towerManager.isphysDmg=true;
		this.towerManager.ismageDmg=false;
		if(attackAreaMeleeEnter.enemy!=null) // check if there is something in front of the tower.  проверить есть ли какой-то объект перед башней.
		{
			if(attackAreaMeleeEnter.enemy.gameObject.tag.Contains("Enemy")) //check if thing in front of tower is actually an enemy. проверить если этот объект с тегом враг
			{
				hp = attackAreaMeleeEnter.enemy.gameObject.GetComponent("Health") as Health; // get health component of an enemy. берем компонент health из объекта врага
				animator = this.GetComponent<Animator>();// animator
				
				// attack with cooldown of two seconds and play animation. атакует с интервалом в две секунды и играет анимацию.
				if (timeStamp<=Time.time)
				{
					hp.getDamage(damage);
					timeStamp=Time.time+2.0f;
					animator.SetBool("Attack",false);		
				}
				
				// if enemy is dead, destroy enemy object. если враг мертв, уничтожаем его объект и ставим idle анимацию.
				if (hp.isDead())
				{
					Destroy(attackAreaMeleeEnter.enemy.gameObject);
					animator.SetBool("Attack",true);
				}	
			}
		}
	}
	// basic ranged attack. проста атака на расстоянии
	public void basicRanged()
	{
		this.towerManager.isphysDmg=true;
		this.towerManager.ismageDmg=false;
		// check which line archer is on and set appropriate trigger area. проверяет на какой линии лучник, и берет линию по которой будет производиться стрельба.
		if(towerManager.isLine0)
		{
			attackAreaRanged = GameObject.Find("ArcherAttackTop");
		}
		if(towerManager.isLine1)
		{
			attackAreaRanged = GameObject.Find("ArcherAttackTop");
		}
		if(towerManager.isLine2)
		{
			attackAreaRanged = GameObject.Find("ArcherAttackTop");
		}
		if(towerManager.isLine3)
		{
			attackAreaRanged = GameObject.Find("ArcherAttackTop");
		}
		if(towerManager.isLine4)
		{
			attackAreaRanged = GameObject.Find("ArcherAttackTop");
		}
		attackAreaRangedEnter=attackAreaRanged.gameObject.GetComponent("AttackAreaEnter") as AttackAreaEnter;
		if (enemy==null)
		{
			enemy = attackAreaRangedEnter.getEnemy();
			if (enemy!=null)
			{
				hp= enemy.GetComponent("Health") as Health;
			}
			else 
			{}
		}
		else
		{
			if (hp.isDead())
			{
				Destroy(hp.gameObject);
				enemy=null;
			}
			if (timeStamp<Time.time)
			{
				hp.getDamage(damage);
				timeStamp=Time.time+2.0f;
			}
		}
		
	}
		
}
