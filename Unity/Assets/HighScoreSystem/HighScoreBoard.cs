using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleShooting;



public class HighScoreBoard : MonoBehaviour {

	private string[] ScoreKey = { "Score_1st", "Score_2nd", "Score_3rd", "Score_4th",
								  "Score_5th", "Score_6th",
			                      "Score_7th", "Score_8th", "Score_9th", "Score_10th"
	};

	private string[] NameKey = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };


	private string IsfirstPlay = "isfirst";
	public Text ScoreBoard;

	public  int[] Scores = new int[10];

	public string[] RankerNames = new string[10];

	//int c = 0;

	private bool IsFinishedInputName = false;
	private string name_now = "";
	private int count = 10;
	public InputField field;
	// Use this for initialization
	void Start () {
        
		ScoreBoard = GetComponent<Text> ();
	
		field = GameObject.Find ("InputField").GetComponent<InputField> ();
		field.gameObject.SetActive (false);
		if (PlayerPrefs.GetInt (IsfirstPlay, -1) == -1) {
			Debug.Log ("初回起動です");
			Resetscore ();
			PlayerPrefs.SetInt (IsfirstPlay, 10);

		}
		else LoadScore ();

		UpdateScoreBoard ();
	
	}
	
	// Update is called once per frame

	private void UpdateScoreBoard() {

		string str = "";
		string[] Ranks = {"1st","2nd","3rd","4th","5th","6th","7th","8th","9th","10th"};

		for (int i = 0; i < 10; i++) {
			//string score = Scores [i].ToString ().ToUpper ();
			str += Ranks [i] + "　" + RankerNames [i] + "　" +  Scores[i].ToString () + "\n";
		}
		Debug.Log ("スコア反映");
		ScoreBoard.text = str;

	}

	public void Resetscore() {
		PlayerPrefs.DeleteAll ();
		field.gameObject.SetActive (false);
		for (int i = 0; i < 10; i++) {
			Scores [i] = 0;
			RankerNames [i] = "なし";
		}
		SaveScore ();
		UpdateScoreBoard ();
	}

	void SaveScore() {
		for (int i = 0; i < 10; i++) {
			PlayerPrefs.SetInt (ScoreKey[i], Scores [i]);
			PlayerPrefs.SetString (NameKey [i], RankerNames [i]);
			PlayerPrefs.Save ();
		}
	}

	void LoadScore() {

		for (int i=0;i<10;i++) {
			Scores [i] = PlayerPrefs.GetInt (ScoreKey [i], -1);
			RankerNames [i] = PlayerPrefs.GetString (NameKey [i], "NULL");
		}
	}


	public void SendHighScore (int value) {

		Debug.Log ("値" + value + "が送られました");
		field.gameObject.SetActive (false);
		count = 10;
		if (value > Scores [9]) {
			Debug.Log ("ハイスコアが更新されます");
			Scores [9] = value;
			Debug.Log ("Score[9] = " + Scores [9]);
			RankerNames [9] = "あなた";

			for (int i = 9; i > 0; i--) {
				if (Scores [i] > Scores [i - 1]) {
					int tmp = Scores [i];
					Scores [i] = Scores [i - 1];
					Scores [i - 1] = tmp;

					string str = RankerNames [i];
					RankerNames [i] = RankerNames [i - 1];
					RankerNames [i - 1] = str;

					count--;

				}
					

			}
			//AskRankerName ();
			//RankerNames [count - 1] = name_now;
			SaveScore ();
            field.gameObject.SetActive(true);
            field.text = "";
            //追加 10/27 13:13
            field.ActivateInputField();

        }

		UpdateScoreBoard ();

        //追加終わり

	}
	public void Input_test() {
		name_now = field.text;
		Debug.Log ("TEST :" + name_now);
	}

	public void EnsurePlef() {
		string str = "";
		for (int i = 0; i < 10; i++) {
			str += "value" + i + " :" + PlayerPrefs.GetInt (ScoreKey [i], -99) + "\n";
		}

		Debug.Log (str);
	}

	public void WhenEndInputName() {//外部のinputfieldからこの関数をよびだす。

        if (field.text=="")
        {
            field.text=("いきりと");
        }
		RankerNames[count - 1] = field.text;
		field.gameObject.SetActive (false);
		SaveScore ();
		UpdateScoreBoard ();
	}
		
}
