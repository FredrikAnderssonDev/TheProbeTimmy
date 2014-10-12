using UnityEngine;
using System.Collections;

public class Level2Handler : LevelHandler {

	public Transform redLaser;
	public Transform box;

	void Start(){
		base.Start();
		Physics2D.IgnoreCollision(redLaser.collider2D,box.collider2D);
	}

	// Removes the collision between the laser and the player
	public void RemoveCollision(Collider2D col){
		Physics2D.IgnoreCollision(col,redLaser.collider2D);
	}
}
