using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandTGTSpawner : Spawner {
    Animation TGTwithPillarAnimation;

    private void Start()
    {
        TGTwithPillarAnimation = transform.GetChild(0).gameObject.GetComponent<Animation>();

    }

    override public void Hit()
    {
        willDeath = true;
        TGTwithPillarAnimation.Play("death");
    }


    // Use this for initialization
    override public void Spawn()
    {
        isAlive = true;
        TGTwithPillarAnimation.Play("Respawn");
    }

}
