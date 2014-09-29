using UnityEngine;
using System.Collections;

public class Level1Handler : MonoBehaviour {

	public Camera mainCam;
	
	public Vector2 posHealth;
	public Vector2 posEndScreen;
	public GUISkin theSkin;

	int health; // Players health
	bool levelDone = false;

	void Start(){
		health = 100;
		// The middle of the screen
		posEndScreen.x = Screen.width/2;
		posEndScreen.y = Screen.height/2;
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
			GUILayout.BeginArea (new Rect (posEndScreen.x-100, posEndScreen.y-100, 200, 200));
			GUILayout.BeginVertical();
			GUILayout.Box ("LEVEL COMPLETED");
			if (GUILayout.Button ("To Menu")){
				Application.LoadLevel("MainMenu");
			}
			if (GUILayout.Button ("Next Level")){
				Application.LoadLevel(Application.loadedLevel + 1);
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
	}

	public void UpdatePlayerHealth(int h){
		health = h;
	}

	public void LevelCompleted(){
		levelDone = true;
	}
}
