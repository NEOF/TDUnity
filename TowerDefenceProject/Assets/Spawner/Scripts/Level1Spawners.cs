using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Spawner))]
public class Level1Spawners : MonoBehaviour
{
	private Spawner spawn;
	private int choice;
	void Start ()
	{
	spawn = gameObject.GetComponent<Spawner>();
	}
	void Update ()
	{
	choice = Random.Range (1,4);
		switch (choice)
		{
			case 1:
			spawn.unitLevel = TD.Spawner.UnitLevels.Enemy1;
			break;
			case 2:
			spawn.unitLevel = TD.Spawner.UnitLevels.Enemy2;
			break;
			case 3:
			spawn.unitLevel = TD.Spawner.UnitLevels.Enemy3;
			break;
		}
		if(spawn.spawnID == 1)
		{
		if(Time.time > 50.0){
			spawn.totalUnits = 10;
			spawn.timeBetweenSpawns = 5;}
		if(Time.time > 100.0){
			spawn.totalUnits = 15;
			spawn.timeBetweenSpawns = 13;
			spawn.waveTimer = 12;}
		}
		if(spawn.spawnID == 2){
		if(Time.time > 50.0){
			spawn.totalUnits = 12;
			spawn.timeBetweenSpawns = 4;}
		if(Time.time > 100.0){
			spawn.totalUnits = 17;
			spawn.timeBetweenSpawns = 11;
			spawn.waveTimer = 11;}
		}
		if(spawn.spawnID == 3){
		if(Time.time > 50.0){
			spawn.totalUnits = 7;
			spawn.timeBetweenSpawns = 7;}
		if(Time.time > 100.0){
			spawn.totalUnits = 18;
			spawn.timeBetweenSpawns = 16;
			spawn.waveTimer = 15;}
		}
		if(spawn.spawnID == 4){
		if(Time.time > 50.0){
			spawn.totalUnits = 8;
			spawn.timeBetweenSpawns = 9;}
		if(Time.time > 100.0){
			spawn.totalUnits = 16;
			spawn.timeBetweenSpawns = 13;
			spawn.waveTimer = 15;}
		}
		if(spawn.spawnID == 5){
		if(Time.time > 50.0){
			spawn.totalUnits = 15;
			spawn.timeBetweenSpawns = 12;}
		if(Time.time > 100.0){
			spawn.totalUnits = 20;
			spawn.timeBetweenSpawns = 12;
			spawn.waveTimer = 15;}
		}
		if(spawn.spawnID == 6){
		if(Time.time > 50.0){
			spawn.totalUnits = 19;
			spawn.timeBetweenSpawns = 15;}
		if(Time.time > 100.0){
			spawn.totalUnits = 25;
			spawn.timeBetweenSpawns = 16;
			spawn.waveTimer = 15;}
		}
	}
}

