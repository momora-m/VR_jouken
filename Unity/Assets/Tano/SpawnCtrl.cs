using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : MonoBehaviour {
    [SerializeField] Spawner[] spawners;
    bool[] isAlives;


	// Use this for initialization
	void Start () {
        spawners.GetLength(0);
        
		
	}

    public void Respawn()
    {
        int spawnNumber;
        while (true)
        {
            spawnNumber = Random.Range(0, spawners.GetLength(0) );
            if (!spawners[spawnNumber].isAlive)
            {
                spawners[spawnNumber].Spawn();
                break;
            }
        }
    }
}
/*
[System.Serializable]
public class SpawnerSet
{
    public GameObject gameObject;
    public bool isAlive;
}
*/
