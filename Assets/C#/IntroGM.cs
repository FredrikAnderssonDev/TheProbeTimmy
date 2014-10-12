using UnityEngine;
using System.Collections;

public class IntroGM : MonoBehaviour {

	public Camera mainCamera;
	public Rigidbody2D helpProbe1;
	public Rigidbody2D helpProbe2;
	public Rigidbody2D helpProbe3;
	public Rigidbody2D playerProbe;
	public int speed = 5;
	public int playerSpeed = 4;

	// Use this for initialization
	void Start () {
		helpProbe1.velocity = new Vector3(speed,0f,0f);
		helpProbe2.velocity = new Vector3(speed,0f,0f);
		helpProbe3.velocity = new Vector3(speed,0f,0f);
		playerProbe.velocity = new Vector3(playerSpeed,0f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(playerProbe.position.x > mainCamera.ScreenToWorldPoint(new Vector3(Screen.width,0f,0f)).x) 
			Application.LoadLevel("MainMenu");
	}
}
