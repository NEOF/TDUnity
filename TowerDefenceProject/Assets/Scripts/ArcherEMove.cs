using UnityEngine;
using System.Collections;

public class ArcherEMove : MonoBehaviour {
	public Transform Target;
	public bool canMove = true;
	public float timeStamp;
	public GameObject Arrow;
	public float movspd;
	void Update () {
		if(canMove == true){
		Target = GameObject.FindWithTag("Tower").transform;
		this.transform.position+=new Vector3(-movspd*Time.deltaTime,0.0f,0.0f*Time.deltaTime);
		}
	}
void OnTriggerStay(Collider col){
		if(col.gameObject.tag == "Tower"){
			this.canMove = false;
			Health hp = col.gameObject.GetComponent("Health") as Health;
			if (timeStamp<=Time.time)
			{
				GameObject fire = Instantiate(Resources.Load("Arrow")) as GameObject;
				fire.transform.position = (this.transform.position + new Vector3(-1.0f,0.0f,0.0f));
				timeStamp = Time.time+2.0f;
			}
			if (hp.isDead())
			{
				canMove = true;
				Destroy(col.gameObject);
			}
		}
	}
}
