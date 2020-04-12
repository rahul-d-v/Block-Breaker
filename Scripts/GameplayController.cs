using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;
	
	[SerializeField]
	private Text lifecount;

	void Awake() {
		MakeInstance();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	
	// Update is called once per frame
	void MakeInstance () {
		if(instance == null){
			instance = this;
			print ("making instance");
		}
	}
	
	public void CountLives(int numLives){
		Debug.Log ("Number of lives is" + numLives);
		lifecount.text = "Lives: " + numLives;
	}
}
