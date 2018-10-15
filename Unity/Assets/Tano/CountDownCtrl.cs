using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class CountDownCtrl : MonoBehaviour {

    bool isCountDownWorking = false;
    public int countDounNumber = 3;
    float remain_sec;
    public UnityEvent timeoverEV;

    Text countDownText;

	// Use this for initialization
	void Start () {
        countDownText = GetComponent<Text>();
        countDownText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if(isCountDownWorking)
        {
            
            remain_sec -= Time.deltaTime;
            countDownText.text = remain_sec.ToString("F0");
            if(remain_sec <= 1)
            {
                countDownText.text = "GO!!";                
            }
            if(remain_sec<=0)
            {
                timeover();
            }
        }
	}

    public void CountDownStart()
    {
        CountDownReset(); 
        isCountDownWorking = true;
    }
    public void CountDownReset()
    {
        remain_sec = countDounNumber;
    }
    void timeover()
    {
        timeoverEV.Invoke();
        Debug.Log("カウントダウンが終了しました");
        isCountDownWorking = false;
        countDownText.text = "";
    }
}
