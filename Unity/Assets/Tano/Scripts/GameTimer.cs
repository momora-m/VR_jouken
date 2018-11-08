using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace SimpleShooting
{
    public class GameTimer : MonoBehaviour
    {
        public float initial_remain_sec = 60;
        public float redLineTime= 10.0f;
        public UnityEvent timeoverEV;
        [SerializeField] AudioClip emargencyCountSE;
        [SerializeField] AudioClip timeoverSE;
        [SerializeField] ScoreUICtrl scoreUICtrl;

        float remain_sec;
        float commaTillSE;
        bool isTimerWorking = false;

        Text timerText;
        AudioSource audioSource;

        private void Reset()
        {
            GameObject.Find("ScoreCanvas").GetComponent<ScoreUICtrl>();
        }

        // Use this for initialization
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            timerText = GetComponent<Text>();
            timerText.text = remain_sec.ToString("F2");
            timerReset();

        }

        // Update is called once per frame
        void Update()
        {
            if (isTimerWorking)
            {
                remain_sec -= Time.deltaTime;

                if(remain_sec < 0f)

                {
                    remain_sec = 0f;
                    isTimerWorking = false;
                    timeover();
                }

                if(remain_sec <= redLineTime)
                {
                    emargencyMode();

                    commaTillSE -= Time.deltaTime;
                    if(commaTillSE <= 0)
                    {
                        emargencyCount();
                        commaTillSE += 1;
                    }
                }

                timerText.text = remain_sec.ToString("F2");
            }
        }


        void emargencyMode()
        {
            timerText.color = Color.red;
            scoreUICtrl.HideScore();
        }

        void emargencyCount()
        {
            audioSource.PlayOneShot(emargencyCountSE);
        }

        void timeover()
        {
            timeoverEV.Invoke();
            audioSource.PlayOneShot(timeoverSE);
            //Debug.Log("制限時間が終了しました");
        }

        public void timerTrigger()
        {
            timerReset();
            isTimerWorking = true;
        }

        public void timerReset()
        {
            isTimerWorking = false;
            commaTillSE = 0;
            remain_sec = initial_remain_sec;
            timerText.text = remain_sec.ToString("F2");
            timerText.color = Color.black;
        }

    }
}
