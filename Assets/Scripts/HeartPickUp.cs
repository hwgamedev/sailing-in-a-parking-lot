using UnityEngine;
using System.Collections;

public class HeartPickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			bool success = col.gameObject.GetComponent<LifeManager> ().incHealth();
			if(success)
				Destroy (gameObject);
		}
	}
}
