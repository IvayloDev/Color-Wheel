using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	Text text;
	public static int Score;

	// Use this for initialization
	void Start () {
		Score = 0;
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "" + Score;
	}
}
