using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	public Animator txtAnimator;
	

	void OnTriggerEnter2D(Collider2D col){

		if(GameController.DifficultyScale >= 0.9f){
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
		}else{
			Application.LoadLevel(Application.loadedLevel);
			}
		}

	void Continue2Next() {
		ScoreScript.Score++;
		txtAnimator.SetTrigger("NewScore");
		GameController.DifficultyScale += 0.03f;
		GameController.NxtLevel = true;
	}
	
	IEnumerator Intense () {
		GameController.DifficultyScale = 0.9f;

		yield return new WaitForSeconds(1f);

		GameController.DifficultyScale = 0.9f;
	
		yield return new WaitForSeconds(1f);
			
		GameController.DifficultyScale = 0.9f;

		yield return new WaitForSeconds(1f);
			
		GameController.DifficultyScale = 0.9f;
		}


	}

