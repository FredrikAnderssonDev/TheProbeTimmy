using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player")
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}
