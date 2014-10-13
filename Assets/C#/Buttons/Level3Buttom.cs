using UnityEngine;
using System.Collections;

public class Level3Buttom : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player")
		{
			Application.LoadLevel("Level3");
		}
	}
}
