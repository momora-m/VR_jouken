using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCtrl : MonoBehaviour {

    public SpawnCtrl spawnCtrl;

	// Use this for initialization
	void Start () {
        spawnCtrl = GameObject.Find("GameMaster").GetComponent<SpawnCtrl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit()
    {
        spawnCtrl.Respawn();
        transform.root.GetComponent<Spawner>().Hit();
    }
}
