using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace SimpleShooting
{
    public class CountDownCtrl : MonoBehaviour {

        [SerializeField] float coolDownSec = 3;
        public UnityEvent timeoverEV;
        [SerializeField] AudioClip[] CountDownSEs;

        bool isCoolDownWorking = false;
        float remain_sec;

        AudioSource audioSource;
        Animation UIanimation;
        TSCtrl tsCtrl;
        Text countDownText;
        [SerializeField] ResultCtrl resultCtrl;

        // Use this for initialization
        void Start() {
            audioSource = GetComponent<AudioSource>();
            UIanimation = GetComponent<Animation>();
            tsCtrl = GameObject.Find("GameMaster").GetComponent<TSCtrl>();
            //resultCtrl = GameObject.Find("ResultCanvas").GetComponent<ResultCtrl>();
            countDownText = GetComponent<Text>();
            countDownText.text = "";
        }

        // Update is called once per frame
        void Update() {

            if (isCoolDownWorking)
            {
                remain_sec -= Time.deltaTime;
                if (remain_sec <= 0)
                {
                    CoolDownOver();
                }
            }
        
        }

        #region CountDownFuncs

        public void CountDownStart()
        {
            UIanimation.Play("CountDown");
        }

        public void CountDownAction(int Num)
        {
            countDownText.text = Num.ToString();
            audioSource.PlayOneShot(CountDownSEs[Num]);
        }

        public void CountDownActionZero()
        {
            countDownText.text = "GO!!";
            audioSource.PlayOneShot(CountDownSEs[0]);
        }

        public void CountDownOver()
        {
            timeoverEV.Invoke();
            countDownText.text = "";
        }

        #endregion

        #region CoolDownFuncs

        public void CoolDownStart()
        {
            remain_sec = coolDownSec;
            isCoolDownWorking = true;
            countDownText.text = "Finish!!";
        }

        public void CoolDownOver()
        {
            isCoolDownWorking = false;
            resultCtrl.ShowResult();
            countDownText.text = "";
        }

           #endregion

    }
}
