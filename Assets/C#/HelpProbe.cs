using UnityEngine;
using System.Collections;

public class HelpProbe : MonoBehaviour {

	public Rigidbody2D helpProbe;
	public int speed;
	public Sprite expSprite;

	// Use this for initialization
	void Start () {
		speed = 1;
		helpProbe.velocity = new Vector3(speed,0,0);
	}

	void OnCollisionEnter2D(Collision2D coll){
		helpProbe.velocity = new Vector3(0,0,0);
		gameObject.GetComponent<SpriteRenderer>().sprite = expSprite;
		StartCoroutine(KillProbe());
	}

	IEnumerator KillProbe(){
		yield return new WaitForSeconds(0.2f);
		Destroy(gameObject);
	}
}
