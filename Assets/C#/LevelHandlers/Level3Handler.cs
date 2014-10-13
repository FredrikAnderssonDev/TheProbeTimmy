using UnityEngine;
using System.Collections;

public class Level3Handler : LevelHandler {

	public Transform redLaser;
	public Transform blueLaser;
	
	// Removes the collision between the red laser and the player
	public void RemoveRedCollision(Collider2D col){
		Physics2D.IgnoreCollision(col,redLaser.collider2D);
	}

}
