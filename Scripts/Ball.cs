using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private bool firstBall = true;
	
	public static Ball instance;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		
		
		MakeInstance();
		SetBallPosition();
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			if (Input.GetMouseButtonDown(0)) {
				print("launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		// Ball does not trigger sound when brick is destoyed.
		// Not 100% sure why, possibly because brick isn't there.
		Vector2 tweak = new Vector2 (Random.Range(-0.3f, 0.3f), Random.Range(0f, 0.3f));
		print (tweak);
		if (hasStarted) {	
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
	
	void MakeInstance () {
		if(instance == null){
			instance = this;
			//print ("making instance");
		}
	}
	
	public void SetBallPosition() {
		if (firstBall){
			paddleToBallVector = this.transform.position - paddle.transform.position;
			firstBall = false; 
		}
		hasStarted = false;
	}
}
