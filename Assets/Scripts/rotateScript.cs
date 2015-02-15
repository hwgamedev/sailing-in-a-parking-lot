using UnityEngine;
using System.Collections;

public class rotateScript : MonoBehaviour {

	private float myXaccel = 0.0f;
	private float smoothSpeed = 8f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


		transform.rotation = Quaternion.identity;
		myXaccel = Mathf.Lerp(myXaccel, Input.acceleration.x, smoothSpeed * Time.deltaTime);
		transform.Rotate (0, 0, myXaccel*90*-1);
	}
}

