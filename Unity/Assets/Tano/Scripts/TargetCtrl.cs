using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleShooting;

namespace SimpleShooting
{
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
        try
        {
            //spawner用
            transform.parent.GetComponent<Spawner>().Hit();
        }
        catch
        {
            //StandTGT用
            transform.parent.parent.GetComponent<Spawner>().Hit();
        }

    }

  
        

    

}
}

