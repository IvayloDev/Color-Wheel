using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	public static int MusicInt;

	public GameObject musicButt;
	public Sprite MusicOnSprite;
	public Sprite MusicOffSprite;

	void Start() {
		MusicInt = 0;
		MusicInt = PlayerPrefs.GetInt("MusicInt", 0);
	}

	public void OnRestartClick() {
		Application.LoadLevel(Application.loadedLevel);
	}
	public void OnLeaderBoardClick() {

		if(!Social.localUser.authenticated){
			Social.localUser.Authenticate(
				(bool success) => {
			});
		}else{
		Social.ShowLeaderboardUI();
		}
	}
	public void OnStarClick() {
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.IvayloDev.ColorWheel");
	}
	public void OnSoundClick() {
		if(MusicInt == 0){
			MusicInt = 1;
		}else{
			MusicInt = 0;
		}
	}

	void OnDestroy() {
		PlayerPrefs.SetInt("MusicInt",MusicInt);
	}

	void Update() {
		if(MusicInt == 1){
			musicButt.GetComponent<Image>().sprite = MusicOffSprite;
			AudioListener.volume = 0;
		}else if(MusicInt == 0){
			musicButt.GetComponent<Image>().sprite = MusicOnSprite;
			AudioListener.volume = 1;
		}

	}

}
