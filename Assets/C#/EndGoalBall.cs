using UnityEngine;
using System.Collections;

public class EndGoalBall : MonoBehaviour {

	GameObject GM; // Gamehandler

	void Start(){
		GM = GameObject.Find("_GM");
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player")
		{
			GM.SendMessage("LevelCompleted");
			Destroy(gameObject);
		}
	}
}
