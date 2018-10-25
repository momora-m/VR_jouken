using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleShooting
{
    public class Spawner : MonoBehaviour {
    [SerializeField] GameObject spawnObject;

    [SerializeField] protected AudioClip[] breakSEs;
    protected AudioSource audioSource;

    virtual protected void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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

    virtual public void Despawn ()
    {
        isAlive = false;
        Destroy(transform.GetChild(0).gameObject);
    }

    virtual public void Hit()
    {
        //リスト内のランダムなSEを鳴らす
        audioSource.PlayOneShot(breakSEs[Random.Range(0, breakSEs.Length)]);
        willDeath = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.2f);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
}

