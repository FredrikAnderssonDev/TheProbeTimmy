using UnityEngine;
using System.Collections;

public class Level2Handler : Level1Handler {

	public Transform redLaser;

	// Removes the collision between the laser and the player
	public void RemoveCollision(Collider2D col){
		Physics2D.IgnoreCollision(col,redLaser.collider2D);
	}
}
