using UnityEngine;
using System.Collections;

public class EMageAtk : MonoBehaviour {
	public Transform Target;
	public float spellspeed = 10;
	public float Dmg = 3;
	public float timeStamp;
	void Start ()
	{
		timeStamp =0.0f;
	}
	void Update () {
		Target = GameObject.FindWithTag ("Tower").transform;
		this.transform.position += new Vector3(-1.0f*spellspeed, 0.0f, 0.0f*Time.deltaTime);
	}
	void OnTriggerEnter (Collider col){
		if(col.gameObject.tag == "Tower"){
			Health hp = col.gameObject.GetComponent("Health") as Health;
			if (timeStamp<=Time.time)
			{
				hp.getDamage(Dmg);
				timeStamp=Time.time+2.0f;
				Destroy(this.gameObject);
			}
			if (hp.isDead())
			{
				Destroy(this.gameObject);
			}
		}
		if(col.gameObject.tag == "End")
			{
				Destroy(this.gameObject);
			}
	}
}
