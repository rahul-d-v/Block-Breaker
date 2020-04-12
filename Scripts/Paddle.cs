using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float speed =20f;

	private Ball ball;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay) {
			if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer){
				MoveWithMouse();
			}
			if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer){
				MoveWithTouch();
			}
		}
		else {
			AutoPlay();
		}
	}
	
	void AutoPlay () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		//float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(ballPos.x, 1.8f, 14.1f);
		this.transform.position = paddlePos;
	}
		
	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1.8f, 14.1f);
		this.transform.position = paddlePos;
	}

	void MoveWithTouch(){
		if (Input.GetMouseButton (0) && Input.mousePosition.x > Screen.width / 2) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else if (Input.GetMouseButton (0) && Input.mousePosition.x < Screen.width / 2) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		paddlePos.x = Mathf.Clamp(transform.position.x, 1.8f, 14.1f);
		this.transform.position = paddlePos;
	}
}
