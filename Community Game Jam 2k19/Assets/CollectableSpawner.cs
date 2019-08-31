using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : SpawnerBase
{
    bool isActive = false;
    [SerializeField]
    LoadingBarValue load;
    [SerializeField]
    InterruptionObject interruption;
    [SerializeField]
    CmdPromptObject cmd;
    HealthController health;
    ItemCollect collect;
    [SerializeField]
    int objectCount = 0;
    // Start is called before the first frame update

 
    void OnEnable()
    {
        objectCount = interruption.difficulty;
        SetUpEnemies();
        Invoke("Spawn", interruption.speed);
    }
    void OnDisable()
    {
        for(int i = 0; i < interruption.difficulty; i++)
        {
            collect = spawnObjects[i].GetComponent<ItemCollect>();
            if (collect != null)
            {
                collect.OnCollected -= HandleCollect;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {

            if (objectCount == 0)
            {
                load.isSlow = false;
                load.tickRate = 0.001f;
                cmd.CmdSetText("Garbage Clear!");
                load.Activate();
                isActive = false;
                gameObject.SetActive(false);
            }
        }
    }

    protected override void Spawn()
    {
        load.Color = Color.yellow;
        load.isSlow = true;
        load.tickRate = 0.0001f;
        isActive = true;

        for (int i = 0; i < interruption.difficulty; i++)
        {
            var enemyToSpawn = getInactiveEnemy();
            if (enemyToSpawn != null)
            {

                enemyToSpawn.transform.position = spawnLocations[i].transform.position;
                health = enemyToSpawn.GetComponent<HealthController>();
                if (health != null)
                {
                    health.IsDead = false;
                    health.CurrentHealth = 1f;
                }
                enemyToSpawn.SetActive(true);
            }
        }

        cmd.CmdSetText("Garbage is Slowing Us Down!");



    }
    //0.0001f for the "slowdown" effect

    GameObject getInactiveEnemy()
    {
        GameObject _enemy = null;
        for (int i = 0; i < interruption.difficulty; i++)
        {
            if (spawnObjects[i].activeInHierarchy == false)
            {
                _enemy = spawnObjects[i];
                break;
            }
        }
        return _enemy;
    }

    void SetUpEnemies()
    {
        for (int i = 0; i < interruption.difficulty; i++)
        {
            spawnObjects[i].SetActive(false);
            health = spawnObjects[i].GetComponent<HealthController>();
            if (health != null)
            {
                spawnObjects[i].GetComponent<HealthController>().IsDead = true;
            }
            collect = spawnObjects[i].GetComponent<ItemCollect>();
            if(collect!= null)
            {
                collect.OnCollected += HandleCollect;
            }
        }
    }

    void HandleCollect()
    {
        objectCount--;
    }


}
