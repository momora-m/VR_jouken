using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleCtrl : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject FireParticle;

    [System.NonSerialized] public float initialVelocity;

    Quaternion bulletRotation = new Quaternion(0, 0, 0, 0);
    GameObject createdBullet;
    BulletCtrl bulletCtrl;

    public void Update()
    {

    }

    public void Fire()
    {
        //パーティクルのオブジェクト作成
        //Instantiate(FireParticle, transform.position, transform.rotation, transform);


        //弾を作成
        createdBullet = Instantiate(bullet, transform.position, bulletRotation);
        //弾にデータを与える
        bulletCtrl = createdBullet.GetComponent<BulletCtrl>();
        createdBullet.GetComponent<Rigidbody>().AddForce(createdBullet.transform.forward * initialVelocity, ForceMode.VelocityChange);
    }

}
