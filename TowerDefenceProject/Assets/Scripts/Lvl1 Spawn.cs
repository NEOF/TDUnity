using UnityEngine;
using System.Collections;

public class Lvl1Spawn : MonoBehaviour {
	GameObject ArcherEnemy;
	GameObject MageEnemy;
	GameObject WarriorEnemy;
	int Enum;
	int i = 0;
void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Tower"){
		do{
		Enum = Random.Range (0,2);
		switch(Enum){
			case 0:
			GameObject enemy = Instantiate(Resources.Load("ArcherEnemy")) as GameObject;
			enemy.transform.position = (this.transform.position + new Vector3(-1.0f,0.0f,1.0f));
			break;
			case 1:
			GameObject enemy1 = Instantiate(Resources.Load("MageEnemy")) as GameObject;
			enemy1.transform.position = (this.transform.position + new Vector3(-1.0f,0.0f,1.0f));
			break;
			case 2:
			GameObject enemy2 = Instantiate(Resources.Load("WarriorEnemy")) as GameObject;
			enemy2.transform.position = (this.transform.position + new Vector3(-1.0f,0.0f,1.0f));
			break;
			}
			++i;
		}while(i<10);
	}
	}
}
