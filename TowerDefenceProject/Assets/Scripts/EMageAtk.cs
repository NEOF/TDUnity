using UnityEngine;
using System.Collections;

public class EMageAtk : MonoBehaviour {
	public float spellspeed = 10;
	public float Dmg = 3;
	public float timeStamp;
	void Start ()
	{
		timeStamp =0.0f;
	}
	void Update () {
			this.transform.position += new Vector3(-1.0f*spellspeed, 0.0f, 0.0f*Time.deltaTime);
	}
	void OnTriggerEnter (Collider col){
		if(col != null ){
			if (col.gameObject.tag == "Tower"){
				Health hp = col.transform.parent.gameObject.GetComponent("Health") as Health;
				if (timeStamp<=Time.time)
				{
					hp.getDamage(Dmg);
					timeStamp=Time.time+2.0f;
					Destroy(this.gameObject);
					col = null;
				}
				if (hp!=null)
				{
				if(hp.isDead()){
					Destroy(col.transform.parent.gameObject);
					Destroy (this.gameObject);
				}
			}

				if(col!=null)
				{
			if(col.gameObject.tag == "End")
				{
					Destroy(this.gameObject);
				}
				
		else{
			col = null;
			}
			}
		}
	}
}
}