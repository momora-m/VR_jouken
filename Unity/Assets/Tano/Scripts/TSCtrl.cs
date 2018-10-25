using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleShooting;

namespace SimpleShooting
{
    public class TSCtrl : MonoBehaviour {

        [SerializeField] CountDownCtrl countDownCtrl;
        [SerializeField] Spawner starterSpawner;

        GameTimer gameTimer;
        SpawnCtrl spawnCtrl;
        ScoreUICtrl scoreUICtrl;

        void Start () {
            spawnCtrl = GetComponent<SpawnCtrl>();
            gameTimer = GameObject.Find("Stage/TimerCanvas/Timer").GetComponent<GameTimer>();
            scoreUICtrl = GameObject.Find("Stage/ScoreCanvas").GetComponent<ScoreUICtrl>();
	    }

        //Starterをスポーンさせる関数
        void StarterRespawn()
        {
            if (!starterSpawner.isAlive)
            {
                starterSpawner.Spawn();
                starterSpawner.gameObject.GetComponentInChildren<Destroyable>().whenHit.AddListener(GameStart);
            }
        }

        public void GameStart()
        {
            countDownCtrl.CountDownStart();
        }

        public void GameOver()
        {
            spawnCtrl.FinishRespawn();
            countDownCtrl.CoolDownStart();
        }

        public void GameOverCoolDownEnd()
        {
            gameTimer.timerReset();
            scoreUICtrl.ResetScore();
            StarterRespawn();
        }
    }
}

