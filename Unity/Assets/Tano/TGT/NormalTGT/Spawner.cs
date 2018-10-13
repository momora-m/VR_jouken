using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] GameObject spawnObject;
    public bool isAlive;
    protected bool willDeath;

    private void Update()
    {
        if (willDeath)
        {
            isAlive = false;
        }
        willDeath = false;
    }

    virtual public void Spawn () {
        isAlive = true;
        GameObject obj =  Instantiate(spawnObject, transform.position, transform.rotation);
        obj.transform.parent = gameObject.transform;
	}
    virtual public void Hit()
    {
        willDeath = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.2f);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
