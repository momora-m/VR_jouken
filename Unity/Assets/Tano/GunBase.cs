using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{

    [SerializeField]
    protected AudioClip shotSe;
    [SerializeField] protected MuzzleCtrl muzleCtrl;
    [SerializeField] protected float initialVelocity;
    protected AudioSource audioSource;
    [System.NonSerialized] private static bool safety = false;

    //protected CharacterController rootCharacterController;

    public static bool Safety
    {
        get
        {
            return safety;
        }

        set
        {
            safety = value;
        }
    }

    protected void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    protected virtual void Start()
    {
        muzleCtrl.initialVelocity = initialVelocity;
    }

    //will be private
    protected virtual void Update()
    {

    }

    protected void Fire()
    {
        if(safety)
        {
            return;
        }


        bulletShoot();

        audioSource.PlayOneShot(shotSe);
    }

    protected virtual void bulletShoot()
    {
        muzleCtrl.Fire();
    }
    
}
