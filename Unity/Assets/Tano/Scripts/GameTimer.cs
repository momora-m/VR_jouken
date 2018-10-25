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

        float remain_sec;
        bool isTimerWorking = false;

        Text timerText;

        // Use this for initialization
        void Start()
        {
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
                }

                timerText.text = remain_sec.ToString("F2");
            }
        }

        public void timerTrigger()
        {
            timerReset();
            isTimerWorking = true;
        }

        public void timerReset()
        {
            remain_sec = initial_remain_sec;
            timerText.text = remain_sec.ToString("F2");
            timerText.color = Color.black;
        }

        void emargencyMode()
        {
            timerText.color = Color.red;
        }

        void timeover()
        {
            timeoverEV.Invoke();
            Debug.Log("制限時間が終了しました");
        }
    }
}
