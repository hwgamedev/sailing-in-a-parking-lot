using UnityEngine;
using System.Collections;

public class rotateScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;
		transform.Rotate (new Vector3 (0, 0, 1), Input.gyro.attitude.z);

	}
}
