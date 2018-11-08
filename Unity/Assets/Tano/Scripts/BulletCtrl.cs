using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShooting
{
    public class BulletCtrl : MonoBehaviour {
        [SerializeField] GameObject hitParticle;
        //[SerializeField] GameObject DestroyParticle;
        [SerializeField] float lifeTime;
        [SerializeField] int BoundableCount; 
        [SerializeField] string[] targetTags;
        bool hitted = false;

        void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
        }

        private void OnCollisionEnter(Collision other)
        {
            if(Hittable(other.gameObject.tag))
            {
                other.gameObject.SendMessage("Hit");
                BulletDestruction(true);
                hitted = true;
                return;
            }

            BoundableCountCheck();
        }

        void BulletDestruction(bool isHit)
        {
            
            if(isHit)
            {
                Instantiate(hitParticle, transform.position, transform.rotation);
            }
            else
            {
                //Instantiate(DestroyParticle, transform.position, transform.rotation);
            }
            
            Destroy(gameObject);
        }

        void BoundableCountCheck()
        {
            if (BoundableCount >= 0)
            {
                BoundableCount--;
                return;
            }

            BulletDestruction(false);
        }

        bool Hittable(string hitObjectTag)
        {
            foreach (string targetTag in targetTags)
            {
                if (hitObjectTag == targetTag)
                {
                    return true;
                }
            }

            return false;
        }

        private void OnDestroy()
        {
            if (!hitted)
            {
                GameObject.Find("ScoreCanvas").SendMessage("ResetCombo");
            }
        }
    }
}
