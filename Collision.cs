using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Collision : MonoBehaviour {

	public Animator txtAnimator;
	public GameObject EndScreen;
	public Animator EndScreenAnim,EndScreenAnim2,EndScreenAnim3,EndScreenAnim4;
	public static bool EndIsOn;
	public AudioClip[] audioClip;

	public void PlaySound(int clip){
		
		GetComponent<AudioSource>().clip = audioClip[clip];
		GetComponent<AudioSource>().Play();
	}

	void OnTriggerEnter2D(Collider2D col){

		if(GameController.DifficultyScale >= 0.6f){
			StartCoroutine(Intense());
		}

		if(GameController.ColorCollisionInt == 0 && this.CompareTag("Green")){
			Destroy(col.gameObject);
			Continue2Next();
		}
		else if(GameController.ColorCollisionInt == 1 && this.CompareTag("Red")){
			Destroy(col.gameObject);
			Continue2Next();
		}
		else if(GameController.ColorCollisionInt == 2 && this.CompareTag("Blue")){
			Destroy(col.gameObject);
			Continue2Next();
		}
		else  if(GameController.ColorCollisionInt == 3 && this.CompareTag("Yellow")){
			Destroy(col.gameObject);
			Continue2Next();
		}
		else  if(GameController.ColorCollisionInt == 4 && this.CompareTag("Orange")){
			Destroy(col.gameObject);
			Continue2Next();
		}
		else  if(GameController.ColorCollisionInt == 6 && this.CompareTag("Gray")){
			Destroy(col.gameObject);
			Continue2Next();
		}
		else  if(GameController.ColorCollisionInt == 7 && this.CompareTag("DarkGray")){
			Destroy(col.gameObject);
			Continue2Next();
		}
		else  if(GameController.ColorCollisionInt == 5 && this.CompareTag("Purple")){
			Destroy(col.gameObject);
			Continue2Next();
		}else{
			Destroy(col.gameObject);
			//play anim for enabling the endscreen
			EndScreenAnim.SetTrigger("EndScreen");
			EndScreenAnim2.SetTrigger("EndScreen");
			EndScreenAnim3.SetTrigger("EndScreen");
			EndScreenAnim4.SetTrigger("EndScreen");
			EndIsOn = true;
			PlaySound(1);
			Ads.adCount++;

			if(Social.localUser.authenticated){
				Social.ReportScore(ScoreScript.HighScore,"CgkI4Zz_mr8IEAIQBg",(bool success) => {
				});
			}

			}
		}

	void Continue2Next() {
		ScoreScript.Score++;
		txtAnimator.SetTrigger("NewScore");
		GameController.DifficultyScale += 0.025f;
		GameController.NxtLevel = true;
		PlaySound(0);
	}
	
	IEnumerator Intense () {
		GameController.DifficultyScale = 0.6f;

		yield return new WaitForSeconds(1f);

		GameController.DifficultyScale = 0.6f;
	
		yield return new WaitForSeconds(1f);
			
		GameController.DifficultyScale = 0.6f;

		yield return new WaitForSeconds(1f);
			
		GameController.DifficultyScale = 0.6f;
		}


	}

