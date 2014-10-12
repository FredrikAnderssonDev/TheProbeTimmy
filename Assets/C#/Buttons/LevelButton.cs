using UnityEngine;
using System.Collections;

public class LevelButton : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player")
		{
			Application.LoadLevel("LevelsMenu");
		}
	}
}
