using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : SpawnerBase
{
    HealthController health;
    [SerializeField]
    EnemyWaveObject enemyWave;
    // Start is called before the first frame update
    void Awake()
    {
        SetUpEnemies();
    }

    void OnEnable()
    {
        InvokeRepeating("Spawn", Random.Range(enemyWave.enemySpeed, enemyWave.enemySpeed+3), Random.Range(enemyWave.difficulty,enemyWave.difficulty+3));
    }


    protected override void Spawn()
    {
        var enemyToSpawn = getInactiveEnemy();
        if(enemyToSpawn != null)
        {
            health = enemyToSpawn.GetComponent<HealthController>();
            enemyToSpawn.transform.position = getRandomSpawnLocation().transform.position;
            health.IsDead = false;
            health.CurrentHealth = 1f;
            enemyToSpawn.SetActive(true);
        }

    }
   GameObject getRandomSpawnLocation()
    {
        return spawnLocations[Random.Range(0, spawnLocations.Capacity)];
    }
    GameObject getInactiveEnemy()
    {
        GameObject _enemy = null;
        for(int i = 0; i < spawnObjects.Count; i++)
        {
            if(spawnObjects[i].activeInHierarchy == false)
            {
                _enemy = spawnObjects[i];
                break;
            }
        }
        return _enemy;
    }
    
    void SetUpEnemies()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            spawnObjects[i].SetActive(false);
            health = spawnObjects[i].GetComponent<HealthController>();
            if (health != null)
            {
                spawnObjects[i].GetComponent<HealthController>().IsDead = true;
            }
        }
    }



}
