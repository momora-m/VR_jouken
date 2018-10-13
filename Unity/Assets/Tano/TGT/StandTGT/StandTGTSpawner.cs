using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandTGTSpawner : Spawner {
    Animation TGTwithPillarAnimation;
    BoxCollider TGTboxcollider;

    private void Start()
    {
        TGTwithPillarAnimation = transform.GetChild(0).gameObject.GetComponent<Animation>();
        TGTboxcollider = transform.GetChild(0).GetChild(0).gameObject.GetComponent<BoxCollider>();

    }

    override public void Hit()
    {
        TGTboxcollider.enabled = false;
        willDeath = true;
        TGTwithPillarAnimation.Play("death");
    }


    // Use this for initialization
    override public void Spawn()
    {
        TGTboxcollider.enabled = true;
        isAlive = true;
        TGTwithPillarAnimation.Play("Respawn");
    }

}
