using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

	public HeartManager hm;
	public float invincibilityTime = 3;
		
	private float invincibilityRemaining;
	private int health = 3;
	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		hm = GameObject.FindGameObjectWithTag ("healthbar").GetComponent<HeartManager> ();
		invincibilityRemaining = invincibilityTime;
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(invincibilityRemaining > 0) {
			invincibilityRemaining -= Time.deltaTime;
			Color c = sr.color;
			c.a = c.a == 255? 50 : 255;
			sr.color = c;
		}
		else
			invincibilityRemaining = 0;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Enemy" && health > 0 && invincibilityRemaining == 0) {
			health--;
			hm.updateHearts(health);
			invincibilityRemaining = invincibilityTime;
		}
	}

	public int getHealth() { return health; }
}
