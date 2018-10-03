using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {
    [SerializeField] GameObject hitParticle;
    [SerializeField] GameObject DestroyParticle;
    [SerializeField] int lifeTime;
    [SerializeField] int BoundableCount; 
    [SerializeField] string[] targetTags;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Hittable(collision.gameObject.tag))
        {
            collision.gameObject.SendMessage("Hit");

            BulletDestruction(true);
            return;
        }

        BoundableCount--;
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
            Instantiate(DestroyParticle, transform.position, transform.rotation);
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
}
