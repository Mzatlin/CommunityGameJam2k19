using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBase : MonoBehaviour, ISpawnable
{
    [SerializeField]
    protected List<GameObject> spawnObjects = new List<GameObject>();
    [SerializeField]
    protected List<GameObject> spawnLocations = new List<GameObject>();

    public void StartSpawn()
    {
        Spawn();
    }

    protected virtual void Spawn()
    {

    }

}
