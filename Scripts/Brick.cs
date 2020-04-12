using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHits;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable) {
			breakableCount++;
		}
		
		
		timesHits=0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.3f);
		bool isBreakable = (this.tag == "Breakable");
		if(isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits () {
		timesHits++;
		int maxHits = hitSprites.Length + 1;
		if (timesHits >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke ();
			Destroy(gameObject);
		}
		else {
			LoadSprites();
		}
	}
	
	void PuffSmoke() {
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites() {
		int spriteIndex = timesHits - 1;
		if (hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else {
			Debug.LogError ("Brick Sprite missing");
		}
	}
	
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
