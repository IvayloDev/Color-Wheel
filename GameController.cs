using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private int RandomPiece;
	private int RandomColor;
	private float scaleUpTime;
	private string InstantiatePiece;
	private Color InstantiateColor;
	private Vector3 Spawnpos = new Vector3(0,0,0);
	private GameObject InstatiatedPiece;
	public Canvas canvas;
	public GameObject Circle;
	public static int ColorCollisionInt;

	public static float DifficultyScale;
	public static bool NxtLevel;

	private Quaternion startingRotation;

	IEnumerator Rotate(int rotationAmount){
		float speed = 30f;
		startingRotation = InstatiatedPiece.transform.rotation;
		Quaternion finalRotation = Quaternion.Euler( 0, 0, rotationAmount ) * startingRotation;
		
		while(InstatiatedPiece.transform.rotation != finalRotation){
			InstatiatedPiece.transform.rotation = Quaternion.Lerp(InstatiatedPiece.transform.rotation, finalRotation, speed*Time.deltaTime);
			yield return 0;
		}
	}

	 void GenLevel() {
		scaleUpTime = 0;
		
		Destroy(InstatiatedPiece);


		//Get a number which can later be set to a piece position and color
		RandomPiece = Random.Range(0,4);
		RandomColor = Random.Range(0,4);

		switch (RandomPiece) {
		case 0:
			InstantiatePiece = "LeftPiecePrefab";
			break;
		case 1:
			InstantiatePiece = "TopPiecePrefab";
			break;
		case 2:
			InstantiatePiece = "RightPiecePrefab";
			break;
		case 3:
			InstantiatePiece = "BottomPiecePrefab";
			break;
		}

		switch (RandomColor) {
		case 0:
			//green
			InstantiateColor = new Color32(76,175,80,255);
			ColorCollisionInt = 0;
			break;
		case 1:
			//red
			InstantiateColor = new Color32(244,67,54,255);
			ColorCollisionInt = 1;
			break;
		case 2:
			//blue
			InstantiateColor = new Color32(33,150,243,255);
			ColorCollisionInt = 2;
			break;
		case 3:
			//yellow
			InstantiateColor = new Color32(255,235,59,255);
			ColorCollisionInt = 3;
			break;
		}

		InstatiatedPiece = Instantiate(Resources.Load(InstantiatePiece),Spawnpos,Quaternion.identity) as GameObject;
		InstatiatedPiece.transform.localScale = new Vector3(0,0,0);
		InstatiatedPiece.transform.SetParent(canvas.transform,false);



	}




	public void onclick(){
		//test button
		Application.LoadLevel(Application.loadedLevel);
	}

	void Start () {
		GenLevel();
		DifficultyScale = 0.4f;
	}



		
		// Update is called once per frame
	void Update () {
	
		if(NxtLevel){
			NxtLevel = false;
			GenLevel();
		}

		if(DifficultyScale > 1.1f){
			DifficultyScale = 1.1f;
		}

		if(Input.GetMouseButtonDown(0)){
				StopAllCoroutines();
			StartCoroutine(Rotate(-90));
		}

		InstatiatedPiece.GetComponent<Image>().color = InstantiateColor;

		InstatiatedPiece.GetComponent<RectTransform>().localScale = new Vector3(scaleUpTime,scaleUpTime,scaleUpTime);
		scaleUpTime += DifficultyScale * Time.deltaTime;

	}
}
