using UnityEngine;
using System.Collections;
using TD.Spawner;

public class SpawnAI : MonoBehaviour, Spawnable
{
    public string spawnerTag = "Spawner";
    private int spawnID = -1;

    public void Remove()
    {
        if (spawnID != -1)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(spawnerTag);
            foreach (GameObject obj in objects)
            {
                obj.SendMessage("KillUnit", spawnID);
            }
            spawnID = -1;
            InstantManagement.Despawn(transform);
        }
    }

    public void SetID(int ID)
    {
        spawnID = ID;
    }
}