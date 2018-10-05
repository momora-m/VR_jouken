using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGun : MonoBehaviour {

    
    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform GunTransform = this.transform;
        Vector3 pos = Player.transform.position;
        pos.x += 1;
        pos.y += 1;
        pos.z += 1;
        GunTransform.position = pos;
    }
}
