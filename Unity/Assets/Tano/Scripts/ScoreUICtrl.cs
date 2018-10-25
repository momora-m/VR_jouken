using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleShooting
{
    public class ScoreUICtrl : MonoBehaviour {
        public int score;
        public int combo;
        public float multipler = 1;
        public HighScoreBoard board;

        Text scoreText;
        Text multiplerText;
        Text comboText;
        Animation comboUIAnimation;

	    void Start () {

            scoreText = transform.Find("ScoreUI").GetComponent<Text>();
            multiplerText = transform.Find("MultiplerUI").GetComponent<Text>();
            comboText = transform.Find("ComboUI").GetComponent<Text>();
            comboUIAnimation = transform.Find("ComboUI").GetComponent<Animation>();

        }

        void multiplerIncrease()
        {
            multipler += 0.3f;
            multiplerText.text = "x" + multipler.ToString("F1");
        }

        public void GainScore(int addScore)
        {
            //コンボ処理
            combo ++;
            comboUIAnimation.Stop();
            comboUIAnimation.Play("ComboIncrease");
            comboText.text = combo.ToString() + "Hit!!";
            if(combo % 10 == 0)
            {
                multiplerIncrease();
            } 

            //スコア処理
            score += (int)(addScore * multipler);
            scoreText.text = score.ToString("d6");
        }

        public void ResetCombo()
        {
            combo = 0;
            comboText.text = "";

            multipler = 1;
            multiplerText.text = "";
        }

        public void ResetScore()
        {
            //ここにハイスコア送信
            board.SendHighScore(score);

            score = 0;
            scoreText.text = score.ToString("d6");

            ResetCombo();
        }

    }
}


