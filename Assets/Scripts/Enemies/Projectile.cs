using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public bool goRight;
	public float maxShootSpeed = 100f;
	public float minShootSpeed = 80f;
	void Start () {
		rigidbody2D.AddTorque (-15);
		ForceApply ();
	}

	void Update () {
	
	}

	void ForceApply ()
	{
		if (goRight)
			rigidbody2D.AddForce(Vector3.right * Random.Range(minShootSpeed, maxShootSpeed));
		else
			rigidbody2D.AddForce(Vector3.left * Random.Range(minShootSpeed, maxShootSpeed));
	}

	void OnCollisionEnter2D ()
	{
		GameObject.Destroy (gameObject);
	}
}
