using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShooting
{
    public class Scorerable : MonoBehaviour {

        public int score;

        public void Hit()
        {
            GameObject.Find("ScoreCanvas").GetComponent<ScoreUICtrl>().GainScore(score);
        }
    }
}

