using UnityEngine;
using System.Collections;

public class GlowingBall : MonoBehaviour {

	public int health = 10;

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<PlayerControl>().HealPlayer(health);
			Destroy(gameObject);
		}
	}
}
