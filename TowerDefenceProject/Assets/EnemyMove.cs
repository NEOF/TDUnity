using UnityEngine;
using System.Collections;	
public class EnemyMove : MonoBehaviour {
	public Transform Target;
	bool canMove = true;
	public float timeStamp;	
<<<<<<< HEAD
=======
	public float dmg;
	public float movespd;
>>>>>>> f999a5e122b0a5ac764514ba3dc0d53f8c06cf53
	// Use this for initialization
	void Start () {
	timeStamp=0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(canMove == true){
			Target = GameObject.FindWithTag("Tower").transform;
<<<<<<< HEAD
			this.transform.position+=new Vector3(-1.0f*Time.deltaTime,0.0f,0.0f*Time.deltaTime);
=======
			this.transform.position+=new Vector3(-movespd*Time.deltaTime,0.0f,0.0f*Time.deltaTime);
>>>>>>> f999a5e122b0a5ac764514ba3dc0d53f8c06cf53
		}
	}
		void OnTriggerStay (Collider col){
		if(col.gameObject.tag == "Tower"){
			this.canMove = false;
			Health hp = col.gameObject.GetComponent("Health") as Health;
			if (timeStamp<=Time.time)
			{
<<<<<<< HEAD
				hp.getDamage(10);
=======
				hp.getDamage(dmg);
>>>>>>> f999a5e122b0a5ac764514ba3dc0d53f8c06cf53
				timeStamp=Time.time+2.0f;
			}
			if (hp.isDead())
			{
				Destroy(col.gameObject);
				canMove = true;
			}
		}
	}
}