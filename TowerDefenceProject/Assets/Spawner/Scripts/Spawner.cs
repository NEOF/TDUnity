using UnityEngine;
using System.Collections.Generic;
using TD.Spawner;
public class Spawner : MonoBehaviour
{
    #region Variables
    public UnitLevels unitLevel = UnitLevels.Enemy1;
    public GameObject[] unitList = new GameObject[4];
    public int totalUnits = 10;
    private int numberOfUnits = 0;
    private int totalSpawnedUnits = 0;
    public int spawnID = 0;
    private bool waveSpawn = true;
    public bool spawn = true;
    public SpawnModes spawnType = SpawnModes.Once;
    public float waveTimer = 30.0f;
    private float lastWaveSpawnTime = 0.0f;
    public int totalWaves = 5;
    private int numWaves = 0;
    private bool checkEnemyLevel = false;
    public float timeBetweenSpawns = 0.5f;
    public Transform spawnLocation;
    #endregion

    void Start()
    {
        if (spawnLocation == null)
        {
            spawnLocation = transform;
        }
        InstantManagement.ReadyPreSpawn(unitList[(int)unitLevel].transform, totalUnits);
        StartCoroutine("DoSpawn");
    }
    private void SpawnUnit()
    {
        if (unitList[(int)unitLevel] != null)
        {
            Transform unit = InstantManagement.Spawn(unitList[(int)unitLevel].transform, spawnLocation.position, Quaternion.Euler (0.0f,270f,0.0f));
            unit.SendMessage("SetID", spawnID);
            numberOfUnits++;
            totalSpawnedUnits++;
        }
        else
        {
            Debug.LogError("Error trying to spawn unit of level " + unitLevel.ToString() + " on spawner " + spawnID + " - No unit set");
            spawn = false;
        }
    }
    public void KillUnit(int sID)
    {
        if (spawnID == sID)
        {
            numberOfUnits--;
        }
    }
    public void EnableSpawner(int sID)
    {
        if (spawnID == sID)
        {
            spawn = true;
            InstantManagement.ReadyPreSpawn(unitList[(int)unitLevel].transform, totalUnits);
            StartCoroutine("DoSpawn");
        }
    }
    public void DisableSpawner(int sID)
    {
        if (spawnID == sID)
        {
            spawn = false;
            StopCoroutine("DoSpawn");
        }
    }
    public float TimeTillWave
    {
        get
        {
            if (numWaves >= totalWaves)
            {
                return 0;
            }
            if ( numberOfUnits > 0)
            {
                return 0;
            }

            float time = (lastWaveSpawnTime + waveTimer) - Time.time;
            if (time >= 0)
                return time;
            else
                return 0;
        }
    }
    public void EnableTrigger()
    {
        spawn = true;
        StartCoroutine("DoSpawn");
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "SpawnIcon.psd");
    }
    public void Reset()
    {
        waveSpawn = false;
        checkEnemyLevel = true;
        numWaves = 0;
        totalSpawnedUnits = 0;
        lastWaveSpawnTime = Time.time;
    }
    public int WavesLeft
    {
        get
        {
            return totalWaves - numWaves;
        }
    }
    private System.Collections.IEnumerator DoSpawn()
    {
        while (spawn)
        {
            switch (spawnType)
            {
                case SpawnModes.Once:
                    if (totalSpawnedUnits >= totalUnits)
                    {
                        spawn = false;
                    }
                    else
                    {
                        yield return new WaitForSeconds(timeBetweenSpawns);
                        SpawnUnit();
                    }
                    break;
                case SpawnModes.Wave:
                    if (numWaves <= totalWaves)
                    {
                        if (waveSpawn)
                        {
                            yield return new WaitForSeconds(timeBetweenSpawns);
                            SpawnUnit();

                            if ((totalSpawnedUnits / (numWaves + 1)) == totalUnits)
                            {
                                waveSpawn = false;
                            }
                        }
                        else
                        {
                            waveSpawn = true;
                            numWaves++;
                            numberOfUnits = 0;
                            lastWaveSpawnTime = Time.time;
                            yield return new WaitForSeconds(waveTimer);
                        }
                    }
                    else
                    {
                        spawn = false;
                    }
                    break;
                default:
                    spawn = false;
                    break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
    public void StartSpawn()
    {
        EnableTrigger();
    }
}