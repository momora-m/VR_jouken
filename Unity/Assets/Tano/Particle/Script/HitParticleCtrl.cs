using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticleCtrl : MonoBehaviour {
    ParticleSystem ps;

    // 起動時に呼び出される
    void Start()
    {
        //向きを反転させる
        transform.Rotate(180, 0, 0);
        ps = GetComponent<ParticleSystem>();
    }

    //毎フレーム呼び出される
    void Update()
    {
        //パーティクル終わったなら
        if (!ps.IsAlive())
        {
            //パーティクルのオブジェクトを消す
            Destroy(gameObject);
        }
    }

}
