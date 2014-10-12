using UnityEngine;
using System.Collections;

public class HighScoreList : MonoBehaviour {

	public Vector2 posEndScreen;
	public GUISkin theSkin;
	int[] highScores;
	int levels;

	void Start () {
		levels = PlayerPrefs.GetInt("NumberOfLevels");
		highScores = new int[levels];
		for(int i = 0; i < levels; i++){
			highScores[i] = PlayerPrefs.GetInt("HighScoreLevel" + (i + 1));
		}
		// The middle of the screen
		posEndScreen.x = Screen.width/2;
		posEndScreen.y = Screen.height/2;
	}
	

	void OnGUI () {
		GUI.skin = theSkin;
		// Draw the end screen
		GUI.backgroundColor = Color.blue;
		GUILayout.BeginArea (new Rect (posEndScreen.x-100, posEndScreen.y-100, 200, 200));
		GUILayout.BeginVertical();
		for(int i = 0; i < levels; i++){
			GUILayout.Box("Level " + (i + 1) + " : " + highScores[i]);
		}
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}
