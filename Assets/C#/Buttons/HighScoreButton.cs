using UnityEngine;
using System.Collections;

public class HighScoreButton : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player")
		{
			Application.LoadLevel("HighScoreMenu");
		}
	}
}
