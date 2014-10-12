using UnityEngine;
using System.Collections;

public class Level1Button : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player")
		{
			Application.LoadLevel("Level1");
		}
	}
}
