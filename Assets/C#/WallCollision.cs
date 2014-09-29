using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour {

	public int wallDamage = 5;

	void OnCollisionEnter2D (Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			coll.gameObject.GetComponent<PlayerControl>().DamagePlayer(wallDamage);
		}
	}
}
