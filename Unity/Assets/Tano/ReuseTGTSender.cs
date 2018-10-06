using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReuseTGTSender : MonoBehaviour {

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Hit()
    {
        transform.parent.parent.SendMessage("Hit");
    }
}
