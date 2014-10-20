using UnityEngine;
using System.Collections;

public class Level3Handler : LevelHandler {

	public Transform redLaser;
	public Transform greenLaser;
	public Transform greenLaser2;
	public Transform purpleLaser;
	public GameObject purpleBall;

	public int laserSpeed = 1;
	bool redActive;
	bool greenActive;
	
	void Start(){
		base.Start();
		purpleBall.SetActive(false);
		redActive = false;
		greenActive = false;
	}

	void Update(){
		base.Update();
		// Rotate the laser while the player is alive
		if(health > 0){
			greenLaser.Rotate(0f,0f,Time.deltaTime + laserSpeed);
			greenLaser2.Rotate(0f,0f,Time.deltaTime + laserSpeed);
		}
	}

	// Removes the collision between the red laser and the player
	public void RemoveRedCollision(Collider2D col){
		Physics2D.IgnoreCollision(col,redLaser.collider2D);
	}
	
	// Removes the collision between the purple laser and the player
	public void RemovePurpleCollision(Collider2D col){
		Physics2D.IgnoreCollision(col,purpleLaser.collider2D);
	}

	// Is called when the red box collides with the red wall
	public void RedBoxCompleted(){
		if(greenActive){
			ActivatePurpleBall();
		} else{
			redActive = true;
		}
	}

	// The same as above but the green box with the green wall
	public void GreenBoxCompleted(){
		if(redActive){
			ActivatePurpleBall();
		} else{
			greenActive = true;
		}
	}
	// Activate the purple ball
	private void ActivatePurpleBall(){
		// Make sure that the ball is only activated once
		if(!purpleBall.activeSelf){
			purpleBall.SetActive(true);
		}
	}

}
