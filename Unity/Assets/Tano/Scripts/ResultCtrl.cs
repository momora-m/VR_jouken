using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;


namespace SimpleShooting
{
    public class ResultCtrl : MonoBehaviour {

        public ScoreUICtrl scoreUICtrl;

        public Text hitText;
        public Text accuraccyText;
        public Text comboText;
        public Text scoreText;
        public Text rankText;
        public HighScoreBoard board;
        public AudioClip rankInSE;

        public int rank;

        Animation UIanimation;
        PlayableDirector playableDirector;
        AudioSource audioSource;
        

        private void Reset()
        {
            hitText = transform.Find("HitText").GetComponent<Text>();
            accuraccyText = transform.Find("AccuracyText").GetComponent<Text>();
            comboText = transform.Find("ComboText").GetComponent<Text>();
            scoreText = transform.Find("ScoreText").GetComponent<Text>();
        }

        // Use this for initialization
        void Start () {
            //UIanimation = GetComponent<Animation>();
            playableDirector = GetComponent<PlayableDirector>();
            audioSource = GetComponent<AudioSource>();
	    }
	
	    // Update is called once per frame
	    void Update () {
	    }

        public void ShowResult()
        {
            hitText.text = scoreUICtrl.hitCount.ToString() + "HIT";
            accuraccyText.text = ( scoreUICtrl.hitCount * 100 / (float)(scoreUICtrl.hitCount + scoreUICtrl.missCount) ).ToString("F1") + "%";
            comboText.text = scoreUICtrl.maxCombo.ToString() + "combo";
            scoreText.text = scoreUICtrl.score.ToString();
            rankText.gameObject.SetActive(false);

            //UIanimation.Play();
            playableDirector.Play();
        }

        public void HighScoreCheck()
        {
            rank = board.SendHighScore(scoreUICtrl.score);
            if(rank == -1)
            {
                return;
            }

            rankText.text = rank.ToString() + "位に入賞しました！！";
            rankText.gameObject.SetActive(true);
            audioSource.PlayOneShot(rankInSE);

        }

        public void EndResult()
        {
            //パネル透明化
            //transform.Find("Panel").gameObject.SetActive(false);
            
            GameObject.Find("GameMaster").GetComponent<TSCtrl>().ResultEnd();
        }
    }
}

