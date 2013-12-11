using UnityEngine;
using System.Collections;	
public class EnemyMove : MonoBehaviour {
	public Transform Target;
	bool canMove = true;
	public float timeStamp;	
	public float dmg;
	public float movespd;
	int num;

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
			animation.Play ("walk");
		}
	}
		void OnTriggerStay (Collider col){
		if(col.gameObject.tag == "Tower"){
			this.canMove = false;

			Health hp = col.transform.parent.gameObject.GetComponent("Health") as Health;
			Health own = this.gameObject.GetComponent("Health") as Health;

			if(canMove == false){
				animation.Play ("taunt");
			}
			if (timeStamp < Time.time)
			{
				hp.getDamage(10);

				hp.getDamage(dmg);
				timeStamp=Time.time+2.0f;
				num = Random.Range (0,1);
				switch(num){
				case 0:
				animation.Play ("attack1");
				break;
				case 1:
				animation.Play ("attack2");
				break;
				}
			}
			if (hp.isDead())
			{
				Destroy(col.transform.parent.gameObject);
				canMove = true;
				animation.Play ("run");
			}
		}
	}
}