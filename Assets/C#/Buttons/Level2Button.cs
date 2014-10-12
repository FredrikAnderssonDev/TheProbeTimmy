using UnityEngine;
using System.Collections;

public class Level2Button : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player")
		{
			Application.LoadLevel("Level2");
		}
	}
}
