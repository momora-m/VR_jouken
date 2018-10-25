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
        Hand hand;

        private Interactable interactable;

        [SerializeField] GameObject bulletShell;
        [SerializeField] AudioClip shotSe;
        [SerializeField] MuzzleCtrl muzleCtrl;
        [SerializeField] Transform shellEjectTransform;

        [SerializeField] Vector3 shellEjectVector = new Vector3(1,0,1);
        [SerializeField] float initialVelocity;
        public ushort viveFrame = 20;

        AudioSource audioSource;

        //static
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

            bulletShoot();
            audioSource.PlayOneShot(shotSe);
            StartCoroutine("Vibration");

            if (bulletShell)
            {
                shellEject();
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

            Vector3 ActualShellEjectVelocity = new Vector3(xForceRand + shellEjectVector.x, yForceRand + shellEjectVector.z,0);
            shellRigidbody.GetComponent<Rigidbody>().AddRelativeForce( ActualShellEjectVelocity, ForceMode.VelocityChange);
            shellRigidbody.GetComponent<Rigidbody>().AddRelativeTorque( xrForceRand, 0, zrForceRand);
        }

        protected IEnumerator Vibration()
        {
            for (int i = viveFrame; i > 0; i--)
            {
                hand.TriggerHapticPulse((ushort)((4000 / viveFrame) * i)); //0-3999
                yield return null;
            }
        }
    
    }

}
