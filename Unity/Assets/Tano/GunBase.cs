using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class GunBase : MonoBehaviour
{
    //VR関連
    public SteamVR_Action_Boolean FireButton;

    public SteamVR_Input_Sources thisHand;
    private Interactable interactable;

    //銃関連
    [SerializeField] AudioClip shotSe;
    [SerializeField] MuzzleCtrl muzleCtrl;
    [SerializeField] float initialVelocity;
    AudioSource audioSource;
    public static bool safety = false;




    //protected CharacterController rootCharacterController;

    protected void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    protected virtual void Start()
    {
        muzleCtrl.initialVelocity = initialVelocity;

        interactable = GetComponent<Interactable>();
        //interactable.activateActionSetOnAttach = actionSet;
    }

    //will be private
    protected virtual void Update()
    {
        //握られていたら
        if (interactable.attachedToHand)
        {
            //thisHandに現在握っている手を代入
            thisHand = interactable.attachedToHand.handType;

            if (FireButton.GetStateDown(thisHand))
            {
                Fire();
            }
        }
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
