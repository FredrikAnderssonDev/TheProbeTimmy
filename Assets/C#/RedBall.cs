using UnityEngine;
using System.Collections;

public class RedBall : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<PlayerControl>().ChangeColor(PlayerColor.RED);
			Destroy(gameObject);
		}
	}
}
