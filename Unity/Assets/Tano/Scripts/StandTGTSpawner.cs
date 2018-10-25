using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleShooting
{
    public class StandTGTSpawner : Spawner {
    Animation TGTwithPillarAnimation;
    BoxCollider TGTboxcollider;

    override protected void Start()
    {
        base.Start();
        TGTwithPillarAnimation = transform.GetChild(0).gameObject.GetComponent<Animation>();
        TGTboxcollider = transform.GetChild(0).GetChild(0).gameObject.GetComponent<BoxCollider>();

    }

    override public void Hit()
    {
        //リスト内のランダムなSEを鳴らす
        audioSource.PlayOneShot(breakSEs[Random.Range(0, breakSEs.Length)]);
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

    //New
     override public void Despawn ()
    {
        TGTboxcollider.enabled = false;
        isAlive = false;
        TGTwithPillarAnimation.Play("death");
    }

}
}

