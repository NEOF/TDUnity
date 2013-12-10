using UnityEngine;
using System.Collections;

public class MageEMove : MonoBehaviour {
	public Transform Target;
	public bool canMove = true;
	public float timeStamp;
	public GameObject EnemySpell;
	public float movspd;
	public GameObject tag;
	// Use this for initialization
	void Start () {
	timeStamp = 0.0f;
		animation.Play ("idle");
		Target = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	if(canMove == true){
			Target = GameObject.FindWithTag("Tower").transform;
			this.transform.position+=new Vector3(-movspd*Time.deltaTime,0.0f,0.0f*Time.deltaTime);
			animation.Play ("run");
			}
	}
	void OnTriggerEnter (Collider col){
		if(col != null){
			if(col.gameObject.tag == "Enemy"){
				Health hp = col.gameObject.GetComponent("Health") as Health;
				hp.increaseMax (10);}
		}
	}
	void OnTriggerStay (Collider col){
		if(col != null){
			if(col.gameObject.tag == "Enemy")
			{
				Health hp = col.gameObject.GetComponent ("Health") as Health;
				if (timeStamp <=Time.time){
					hp.getHeal (5);
					timeStamp = Time.time+2.0f;
					animation.Play ("attack");
				}
			}
			if(col.gameObject.tag == "Tower"){
				this.canMove = false;
				Health hp = col.gameObject.GetComponent("Health") as Health;
				if (timeStamp<=Time.time)
				{
					GameObject fire = Instantiate(Resources.Load("EnemySpell")) as GameObject;
					GameObject fire2 = Instantiate(Resources.Load("EnemySpell")) as GameObject;
					GameObject fire3 = Instantiate(Resources.Load("EnemySpell")) as GameObject;
					fire.transform.position = (this.transform.position + new Vector3(-1.0f,0.0f,0.0f));
					fire2.transform.position = (this.transform.position + new Vector3(-1.0f,0.0f,2.0f));
					fire3.transform.position = (this.transform.position + new Vector3(-1.0f,0.0f,-2.0f));
					timeStamp=Time.time+2.0f;
				}
				if (hp!=null)
				{
				if (hp.isDead())
				{
					canMove = true;
					Destroy(col.gameObject);
					col = null;
				}
				}
			}
		}
		else{
			col = null;
		}
	}
	void OnTriggerExit (Collider col){
		if(col.gameObject.tag != null){
			if(col.gameObject.tag == "Enemy"){
				Health hp = col.gameObject.GetComponent("Health") as Health;
				hp.decreaseMax (10);
			}
		}
	}
}