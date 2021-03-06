﻿using UnityEngine;
using System.Collections;

using UnityEditor; // For AssetsDatabase

public enum PlayerColor{WHITE = 0, RED = 1, PURPLE = 2};

public class PlayerControl : MonoBehaviour {

	public int moveSpeed = 2;  // Units per second
	public int health; // Players health
	GameObject GM; // Gamehandler
	public Sprite redProbe;
	public Sprite whiteProbe;
	public Sprite purpleProbe;
	public bool levelDone {set; get;}
	bool immortal;

	// Initialization
	void Start () {
		health = 20;
		immortal = false;
		GM = GameObject.Find("_GM");
	}
	
	// Update is called once per frame
	void Update () {
		// If the player is dead, do not move it
		if(health <= 0 || levelDone){
			rigidbody2D.velocity = new Vector3(0,0,0);
			return;
		}

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
		if(immortal) return;
		immortal = true;
		health = health - dmg < 0 ? 0 : health - dmg;
		audio.Play();
		GM.SendMessage("UpdatePlayerHealth",health);
		StartCoroutine(Blink());
	}

	IEnumerator Blink(){
		float endTime = Time.time + 2.0f;
		while(Time.time < endTime){
			renderer.enabled = false;
			yield return new WaitForSeconds(0.2f);
			renderer.enabled = true;
			yield return new WaitForSeconds(0.2f);
		}
		immortal = false;
	}

	// Set the palyers health to zero
	public void KillPlayer(){
		DamagePlayer(health);
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
			GM.SendMessage("RemoveRedCollision",gameObject.collider2D);
			break;

		case PlayerColor.WHITE:
			gameObject.GetComponent<SpriteRenderer>().sprite = whiteProbe;
			break;
		case PlayerColor.PURPLE:
			gameObject.GetComponent<SpriteRenderer>().sprite = purpleProbe;
			GM.SendMessage("RemovePurpleCollision",gameObject.collider2D);
			break;
		}
	}
	
}
