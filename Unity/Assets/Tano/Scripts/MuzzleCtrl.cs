using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShooting
{
    public class MuzzleCtrl : MonoBehaviour
    {
        [SerializeField] GameObject bullet;
        [SerializeField] GameObject FireParticle;

        [System.NonSerialized] public float initialVelocity;

        GameObject createdBullet;
        BulletCtrl bulletCtrl;

        public void Fire()
        {
            //パーティクルのオブジェクト作成
            if(0 == 0)
            {
                Instantiate(FireParticle, transform.position, transform.rotation, transform);
            }


            //弾を作成
            createdBullet = Instantiate(bullet, transform.position, transform.rotation);
            //弾にデータを与える
            bulletCtrl = createdBullet.GetComponent<BulletCtrl>();
            createdBullet.GetComponent<Rigidbody>().AddForce(createdBullet.transform.forward * initialVelocity, ForceMode.VelocityChange);
        }

    }
}

