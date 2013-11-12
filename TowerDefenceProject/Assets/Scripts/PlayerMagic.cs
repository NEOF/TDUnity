using UnityEngine;
using System.Collections;

public class PlayerMagic : MonoBehaviour {
	public bool isActive1;
	public bool isActive2;
	public bool isActive3;
	public bool isMeteorSpell1;
	public bool isMeteorSpell2;
	public bool isMeteorSpell3;
	public bool isHealSpell1;
	public bool isHealSpell2;
	public bool isHealSpell3;
	// Use this for initialization
	void Start () {
		isActive1=false;
		isActive2=false;
		isActive3=false;
		isMeteorSpell1=false;
		isMeteorSpell2=false;
		isMeteorSpell3=false;
		
		isHealSpell1=false;
		isHealSpell2=false;
		isHealSpell3=false;
	}
	
	// Update is called once per frame
	void Update () {
	chooseSpell();
	if(isActive1 || isActive2 || isActive3)
	{
		Spell1();
		Spell2();
		Spell3();
	}
	}
	void Spell1()
	{
		if (isActive1 && !isActive2 && !isActive3)
		{
		if (isMeteorSpell1 && !isMeteorSpell2 && !isMeteorSpell3)
		{
			Meteor ();
		}
		if (isHealSpell1 && !isHealSpell2 && !isHealSpell3)
		{
			Heal ();
		}
		}
	}
	void Spell2()
	{
		if(isActive2 && !isActive1 && !isActive3)
		{
		if (!isMeteorSpell1 && isMeteorSpell2 && !isMeteorSpell3)
		{
			Meteor ();
		}
		if (!isHealSpell1 && isHealSpell2 && !isHealSpell3)
		{
			Heal ();
		}
		}
	}
	void Spell3()
	{
		if(!isActive2 && !isActive1 && isActive3)
		{
		if (!isMeteorSpell1 && !isMeteorSpell2 && isMeteorSpell3)
		{
			Meteor ();
		}
		if (!isHealSpell1 && !isHealSpell2 && isHealSpell3)
		{
			Heal ();
		}
		}
	}
	void Meteor()
	{
	}
	void Heal()
	{
	}
	void Raycasting()
	{
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit))
			{
			}
		}
	}

	
	void chooseSpell()
	{
		if (Input.GetKey(KeyCode.Q))
		{
			if (isActive1)
			{
				isActive1=false;
			}
			else 
			{
				isActive1=true;
				isActive2=false;
				isActive3=false;
			}
		}
		if (Input.GetKey(KeyCode.W))
		{
			if (isActive2)
			{
				isActive2=false;
			}
			else 
			{
				isActive2=true;
				isActive1=false;
				isActive3=false;
			}
		}
		if (Input.GetKey(KeyCode.E))
		{
			if (isActive3)
			{
				isActive3=false;
			}
			else 
			{
				isActive2=false;
				isActive1=false;
				isActive3=true;
			}
		}
	}
}
