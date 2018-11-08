using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace SimpleShooting
{
    public class GunBase : MonoBehaviour
    {
        //VR関連
        public SteamVR_Action_Boolean FireButton;
        public Hand hand;

        protected Interactable interactable;

        [SerializeField] protected GameObject bulletShell;
        [SerializeField] protected AudioClip shotSe;

        [Space(15)]
        [SerializeField] protected MuzzleCtrl muzleCtrl;
        [Space(15)]
        [SerializeField] protected Transform shellEjectTransform;
        [SerializeField] protected Vector3 shellEjectVector = new Vector3(1,1,0);
        [SerializeField] protected Vector3 shellEjectTorque = new Vector3(1, 0, 1);


        [Space(15)]
        [SerializeField] protected float initialVelocity = 300;
        [Space(15)]
        public ushort viveFrame = 20;
        [Space(15)]
        public bool hasBulletLoadWait = false;
        public float bulletLoadWait;

        protected AudioSource audioSource;
        protected Animator animator;
        protected bool bulletLoaded = true;

        //static
        public static bool safety = false;

        protected void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Use this for initialization
        protected virtual void Start()
        {
            muzleCtrl.initialVelocity = initialVelocity;
            animator = GetComponent<Animator>();

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
                hand = interactable.attachedToHand;

                if (FireButton.GetStateDown(hand.handType))
                {
                    Fire();
                }
            }
        }

        protected void Fire()
        {  
            if (safety)
            {
                return;
            }

            if (!bulletLoaded)
            {
                return;
            }

            bulletShoot();
            audioSource.PlayOneShot(shotSe);
            StartCoroutine("Vibration");

            if (animator)
            {
                animator.SetTrigger("Fire");
            }

            if (bulletShell)
            {
                shellEject();
            }

            if (hasBulletLoadWait)
            {
                bulletLoaded = false;
                StartCoroutine(bulletLoading());
            }
        }

        protected virtual void bulletShoot()
        {
            muzleCtrl.Fire();
        }

        protected void shellEject()
        {
            //薬莢を作成
            Rigidbody shellRigidbody = Instantiate(bulletShell, shellEjectTransform.position,shellEjectTransform.rotation).GetComponent<Rigidbody>();

            //薬莢にデータを与える
            float xForceRand = Random.Range(-0.3f, 0.3f);
            float yForceRand = Random.Range(-0.3f, 0.3f);

            float xrForceRand = Random.Range(-90, 90);
            float zrForceRand = Random.Range(-180, 180);


            int direction;

            if(hand.gameObject.name == "RightHand")
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            Vector3 ActualShellEjectVelocity = new Vector3( (xForceRand + shellEjectVector.x) * direction , yForceRand + shellEjectVector.y,shellEjectVector.z);
            Vector3 ActualShellEjectTorque = new Vector3(shellEjectTorque.x +xrForceRand, shellEjectTorque.y, shellEjectTorque.z + zrForceRand);

            shellRigidbody.GetComponent<Rigidbody>().AddRelativeForce( ActualShellEjectVelocity, ForceMode.VelocityChange);
            shellRigidbody.GetComponent<Rigidbody>().AddRelativeTorque(ActualShellEjectTorque);
        }

        protected IEnumerator Vibration()
        {
            for (int i = viveFrame; i > 0; i--)
            {
                
                hand.TriggerHapticPulse((ushort)((4000 / viveFrame) * i)); //0-3999
                yield return null;
            }
        }

        protected IEnumerator bulletLoading()
        {
            yield return new WaitForSeconds(bulletLoadWait);
            bulletLoaded = true;
        }
    }

}
