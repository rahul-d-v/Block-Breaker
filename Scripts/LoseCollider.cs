using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	public static int numLives;
	public static bool firstLevelLoaded = true;
	
	private LevelManager levelManager;
	
	[SerializeField]
	private AudioClip ballLostSound;
	
	void Start() {
		if(firstLevelLoaded){
			numLives = 3;
			firstLevelLoaded = false;
		}
	}
	
	void OnTriggerEnter2D (Collider2D trigger){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		numLives--;
		if (numLives < 0) {
			levelManager.LoadLevel ("Lose");
			firstLevelLoaded = true;
		}
		else {
			GameplayController.instance.CountLives(numLives);
			Ball.instance.SetBallPosition();
		}
		AudioSource.PlayClipAtPoint (ballLostSound, transform.position, 1f);
		
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		print ("Collision");
	}
}
