using UnityEngine;
using System.Collections;

public class LaserCollider : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			coll.gameObject.GetComponent<PlayerControl>().KillPlayer();
		}
	}

}
