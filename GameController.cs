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
	public GameObject tap2PlayGO;
	public Animator StartAnim;
	public AudioSource FirstTapSound;
	public static bool activateScore = false;
	public static bool sawOnce = false;

	public static float DifficultyScale;
	public static bool NxtLevel;

	private Quaternion startingRotation;

	IEnumerator Rotate(int rotationAmount){
		float speed = 38f;
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
		RandomPiece = Random.Range(0,8);
		RandomColor = Random.Range(0,8);

		switch (RandomPiece) {
		case 0:
			InstantiatePiece = "Prefab1";
			break;
		case 1:
			InstantiatePiece = "Prefab2";
			break;
		case 2:
			InstantiatePiece = "Prefab3";
			break;
		case 3:
			InstantiatePiece = "Prefab4";
			break;
		case 4:
			InstantiatePiece = "Prefab5";
			break;
		case 5:
			InstantiatePiece = "Prefab6";
			break;
		case 6:
			InstantiatePiece = "Prefab7";
			break;
		case 7:
			InstantiatePiece = "Prefab8";
			break;
		}

		switch (RandomColor) {
		case 0:
			//green
			InstantiateColor = new Color32(71,167,126,255);
			ColorCollisionInt = 0;
			break;
		case 1:
			//red
			InstantiateColor = new Color32(243,112,115,255);
			ColorCollisionInt = 1;
			break;
		case 2:
			//blue
			InstantiateColor = new Color32(30,154,195,255);
			ColorCollisionInt = 2;
			break;
		case 3:
			//yellow
			InstantiateColor = new Color32(255,235,59,255);
			ColorCollisionInt = 3;
			break;
		case 4:
			//orange
			InstantiateColor = new Color32(255,152,0,255);
			ColorCollisionInt = 4;
			break;
		case 5:
			//purple
			InstantiateColor = new Color32(152,98,167,255);
			ColorCollisionInt = 5;
			break;
		case 6:
			//gray
			InstantiateColor = new Color32(158,158,158,255);
			ColorCollisionInt = 6;
			break;
		case 7:
			//dark gray
			InstantiateColor = new Color32(121,85,72,255);
			ColorCollisionInt = 7;
			break;
		}

		InstatiatedPiece = Instantiate(Resources.Load(InstantiatePiece),Spawnpos,Quaternion.identity) as GameObject;
		InstatiatedPiece.transform.localScale = new Vector3(0,0,0);
		InstatiatedPiece.transform.SetParent(canvas.transform,false);





		InstatiatedPiece.GetComponent<Image>().color = InstantiateColor;
		

	}

	IEnumerator StartCor() {
		yield return new WaitForSeconds(0.5f);
			tap2PlayGO.SetActive(false);
	}

	void Start () {

		activateScore = false;
		DifficultyScale = 0.34f;

		if(!sawOnce){
			tap2PlayGO.SetActive(true);
			activateScore = false;
		}else{
			tap2PlayGO.SetActive(false);
			GenLevel();
			activateScore = true;
			
		}
			sawOnce = true;
	}


		// Update is called once per frame
	void Update () {

		if(NxtLevel){
			NxtLevel = false;
			GenLevel();
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

		if(ScoreScript.Score > 20){
			DifficultyScale = 0.7f;
		}
		if(ScoreScript.Score > 30){
			DifficultyScale = 0.8f;
		}

		if(Input.GetMouseButtonDown(0) && tap2PlayGO.activeInHierarchy){
			FirstTapSound.Play();
			StartAnim.SetBool("StartBool",true);
			StartCoroutine(StartCor());
			activateScore = true;
			GenLevel();
		}

		if(Input.GetMouseButtonDown(0)&& !tap2PlayGO.activeInHierarchy){
				StopAllCoroutines();
			StartCoroutine(Rotate(-45));
		}

		if(InstatiatedPiece != null){
		InstatiatedPiece.GetComponent<RectTransform>().localScale = new Vector3(scaleUpTime,scaleUpTime,scaleUpTime);
		}
		scaleUpTime += DifficultyScale * Time.deltaTime;

	}
}
