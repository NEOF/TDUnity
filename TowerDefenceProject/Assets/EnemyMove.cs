using UnityEngine;
using System.Collections;	
public class EnemyMove : MonoBehaviour {
	public Transform Target;
	bool canMove = true;
	public float timeStamp;	


	public float dmg;
	public float movespd;

	// Use this for initialization
	void Start () {
	timeStamp=0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(canMove == true){
			Target = GameObject.FindWithTag("Tower").transform;

			this.transform.position+=new Vector3(-1.0f*Time.deltaTime,0.0f,0.0f*Time.deltaTime);

			this.transform.position+=new Vector3(-movespd*Time.deltaTime,0.0f,0.0f*Time.deltaTime);

		}
	}
		void OnTriggerStay (Collider col){
		if(col.gameObject.tag == "Tower"){
			this.canMove = false;
			Health hp = col.gameObject.GetComponent("Health") as Health;
			if (timeStamp<=Time.time)
			{

				hp.getDamage(10);

				hp.getDamage(dmg);

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