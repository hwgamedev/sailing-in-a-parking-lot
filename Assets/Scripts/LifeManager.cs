using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

	public HeartManager hm;
		
	private int health = 3;

	// Use this for initialization
	void Start () {
		hm = GameObject.FindGameObjectWithTag ("healthbar").GetComponent<HeartManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Enemy" && health > 0) {
			health--;
			hm.updateHearts(health);
		}
	}

	public int getHealth() { return health; }
}
