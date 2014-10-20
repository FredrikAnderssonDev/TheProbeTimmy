using UnityEngine;
using System.Collections;

public class LevelHandler : MonoBehaviour {

	public Camera mainCam;
	
	public Vector2 posHealth;
	public Vector2 posEndScreen;
	public GUISkin theSkin;

	protected int health; // Players health
	bool levelDone = false;
	float time;
	int playerScore;
	bool hasNextLevel;
	bool newHighScore;

	protected void Start(){
		health = 20;
		time = 0.0f;
		// The middle of the screen
		posEndScreen.x = Screen.width/2;
		posEndScreen.y = Screen.height/2;
		hasNextLevel = PlayerPrefs.GetInt("NumberOfLevels") > Application.loadedLevel + 1;
		newHighScore = false;
	}

	void OnGUI(){
		// Top rigth of the screen
		posHealth.x = 10;
		posHealth.y = 5;
		
		// Draw the text
		GUI.skin = theSkin;
		GUI.Label (new Rect(posHealth.x, posHealth.y, 100, 100), "Player Health: " + health);

		if(health <= 0){
			// If player is dead, show end screen

			// Draw the end screen
			GUI.backgroundColor = Color.blue;
			GUILayout.BeginArea (new Rect (posEndScreen.x-100, posEndScreen.y-100, 200, 200));
			GUILayout.BeginVertical();
			GUILayout.Box ("GAME OVER");
			if (GUILayout.Button ("To Menu")){
				Application.LoadLevel("MainMenu");
			}
			if (GUILayout.Button ("Restart Level")){
				Application.LoadLevel(Application.loadedLevel);
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}

		if(levelDone){
			// Player has completed the level

			GUI.backgroundColor = Color.blue;
			GUILayout.BeginArea (new Rect (posEndScreen.x-125, posEndScreen.y-125, 250, 250));
			GUILayout.BeginVertical();
			GUILayout.Box("LEVEL COMPLETED");
			if(newHighScore) GUILayout.Box("NEW HIGHSCORE!");
			GUILayout.Box("SCORE: " + playerScore);
			if (GUILayout.Button ("To Menu")){
				Application.LoadLevel("MainMenu");
			}
			if(hasNextLevel){
				if (GUILayout.Button ("Next Level")){
					Application.LoadLevel(Application.loadedLevel + 1);
				}
			}
			else{
				GUILayout.Box("LAST LEVEL");
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
	}

	protected void Update(){
		time = time + Time.deltaTime;
	}

	public void UpdatePlayerHealth(int h){
		health = h;
	}

	public void LevelCompleted(){
		// Calculate the score
		playerScore = health * 100 + (int)System.Math.Ceiling(30000.0f/time);
		// Check new high score
		string level = "HighScoreLevel" + (Application.loadedLevel + 1);
		if(!PlayerPrefs.HasKey(level) || PlayerPrefs.GetInt(level) < playerScore){
			newHighScore = true;
			PlayerPrefs.SetInt(level,playerScore);
		}
		levelDone = true;
	}

}
