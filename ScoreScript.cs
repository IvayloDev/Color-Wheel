using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	Text text;
	public Text highScoreText;
	public static int Score;
	public static int HighScore;

	// Use this for initialization
	void Start () {
		highScoreText.enabled = false;
		Collision.EndIsOn = false;
		Score = 0;
		HighScore = 0;
		HighScore = PlayerPrefs.GetInt("HighScore",0);
		text = GetComponent<Text>();
		highScoreText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Score >= HighScore){
			HighScore = Score;
		}

		if(!GameController.activateScore){
			text.text = "";
		}else{
			text.text = "" + Score;
		}

		if(Collision.EndIsOn){
			highScoreText.enabled = true;
			text.text = ""  + HighScore;
		}

	


	}
	void OnDestroy(){
		PlayerPrefs.SetInt("HighScore", HighScore);
	}
}
