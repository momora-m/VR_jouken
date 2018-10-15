using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : MonoBehaviour {
    [SerializeField] Spawner[] spawners;
    bool[] isAlives;
    bool isStartRespawn = false;  //New

	// Use this for initialization
	void Start () {
        spawners.GetLength(0);
        
		
	}

    public void Respawn()
    {
        int spawnNumber;
        while (isStartRespawn)
        {
            spawnNumber = Random.Range(0, spawners.GetLength(0) );
            if (!spawners[spawnNumber].isAlive)
            {
                Debug.Log("respawn_"+spawnNumber);
                spawners[spawnNumber].Spawn();
                break;
            }
        }
    }

    public void Despawn()
    {
        int spawnNumber;
        while (true)
        {
            spawnNumber = Random.Range(0, spawners.GetLength(0));
            if (spawners[spawnNumber].isAlive)
            {
                Debug.Log("despawn_" + spawnNumber);
                spawners[spawnNumber].Despawn();
                break;
            }
        }
    }

    public void StartRespawn()   //New
    {
        Debug.Log("リスポーンが開始されます");
        isStartRespawn = true;
        Respawn();
        Respawn();
    }

    

    public void FinishRespawn()
    {
        Debug.Log("TGTのリスポーンが終了しました");
        isStartRespawn = false;
        Despawn();
        Despawn();
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
