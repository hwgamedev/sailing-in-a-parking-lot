using UnityEngine;
using System.Collections;

public class platforms : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(17,5);
		Physics2D.IgnoreLayerCollision(18,5);
		Physics2D.IgnoreLayerCollision(18,16);
		Physics2D.IgnoreLayerCollision(18,19);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
