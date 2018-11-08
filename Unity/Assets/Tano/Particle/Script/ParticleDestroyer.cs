using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour {
    //パーティクルが終わったら、パーティクルがついてるobjectを消すプログラム
    ParticleSystem ps;

    // 起動時に呼び出される
    void Start()
    {
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
