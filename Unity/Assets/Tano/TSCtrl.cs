using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSCtrl : MonoBehaviour {
    [SerializeField] CountDownCtrl countDownCtrl;
    [SerializeField] Spawner spawner;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStarter()
    {
        countDownCtrl.CountDownStart();
    }

    public void Respawn()
    {
        if (!spawner.isAlive)
        {
            spawner.Spawn();
            spawner.gameObject.GetComponentInChildren<Destroyable>().whenHit.AddListener(GameStarter);
        }
        
    }

}
