using UnityEngine;
using System.Collections;

public class Artifact : MonoBehaviour {

	private GameObject sm;
	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(15,16);
		Physics2D.IgnoreLayerCollision(15,19);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			sm = GameObject.FindGameObjectWithTag("SceneManager");
			sm.GetComponent<SceneManager>().gameWon();
		}
	}

}
