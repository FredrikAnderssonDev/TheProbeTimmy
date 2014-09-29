using UnityEngine;
using System.Collections;

using UnityEditor; // For AssetsDatabase

public enum PlayerColor{WHITE = 0, RED = 1};

public class PlayerControl : MonoBehaviour {

	public int moveSpeed = 2;  // Units per second
	public int health; // Players health
	GameObject GM; // Gamehandler
	public Sprite redProbe;
	public Sprite whiteProbe;
	//PlayerColor playerColor {get; private set;} // The palyers color

	// Initialization
	void Start () {
		health = 10;
		GM = GameObject.Find("_GM");
	}
	
	// Update is called once per frame
	void Update () {
		// If the player is dead, do not move it
		if(health <= 0) return;

		// The player controls
		if(Input.GetMouseButton(0)){
			var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var playerPos = transform.position;
			var forceX = targetPos.x - playerPos.x;
			var forceY = targetPos.y - playerPos.y;
			rigidbody2D.AddForce(new Vector2(moveSpeed*forceX,moveSpeed*forceY));
		}
	}

	// Deal damage to the player
	public void DamagePlayer(int dmg){
		health = health - dmg;
		GM.SendMessage("UpdatePlayerHealth",health);
	}

	// Heal the player
	public void HealPlayer(int he){
		health = health + he;
		GM.SendMessage("UpdatePlayerHealth",health);
	}

	public void ChangeColor(PlayerColor color){
		switch(color){
		case PlayerColor.RED:
			gameObject.GetComponent<SpriteRenderer>().sprite = redProbe;
			GM.SendMessage("RemoveCollision",gameObject.collider2D);
			break;

		case PlayerColor.WHITE:
			gameObject.GetComponent<SpriteRenderer>().sprite = whiteProbe;
			break;

		}
	}
}
