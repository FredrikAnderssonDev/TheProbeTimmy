using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

	public Camera mainCam;

	public BoxCollider2D topWall;
	public BoxCollider2D bottomWall;
	public BoxCollider2D leftWall;
	public BoxCollider2D rightWall;

	public Transform player;
	public GUISkin theSkin;
	string header = "The Probe Timmy";
	public int offset;

	void Start () {
		// Make walls on the edge of the screen
		topWall.size = new Vector2(mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f,0f,0f)).x , 1f);
		topWall.center = new Vector2(0f, mainCam.ScreenToWorldPoint (new Vector3 (0f,Screen.height,0f)).y + 0.5f);
		
		bottomWall.size = new Vector2(mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f,0f,0f)).x , 1f);
		bottomWall.center = new Vector2(0f, mainCam.ScreenToWorldPoint (new Vector3 (0f,0f,0f)).y - 0.5f);
		
		leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint (new Vector3 (0f,Screen.height * 2f,0f)).y);
		leftWall.center = new Vector2(mainCam.ScreenToWorldPoint (new Vector3 (0f,0f,0f)).x - 0.5f, 0f);
		
		rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint (new Vector3 (0f,Screen.height * 2f,0f)).y);
		rightWall.center = new Vector2( mainCam.ScreenToWorldPoint (new Vector3 (Screen.width, 0f, 0f)).x + 0.5f, 0f);

		/*player.position = new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width / 2f, 0f, 0f)).x,
		                              mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height / 2f, 0f)).y,
		                              0f);*/
		// Offset of the header
		offset = 80;

		// Set the number of levels
		PlayerPrefs.SetInt("NumberOfLevels",3);
	}
	
	void OnGUI(){
		GUI.skin = theSkin;
		GUI.Label(new Rect(0, 0, Screen.width, 100), header);
	}

	void Update(){
		// Reset the high scores
		if(Input.GetKeyDown(KeyCode.R)){
			int levels = PlayerPrefs.GetInt("NumberOfLevels");
			for(int i = 0; i < levels; i++){
				PlayerPrefs.DeleteKey("HighScoreLevel" + (i + 1));
			}
		}
	}
}
