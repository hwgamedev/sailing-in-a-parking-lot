using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public bool goRight;
	private float originalXPos;
	public float maxShootSpeed = 100f;
	public float minShootSpeed = 80f;
	public float range = 20f;
	void Start () {
		originalXPos = transform.position.x;
		rigidbody2D.AddTorque (-15);
		ForceApply ();
	}

	void Update () {
		if (Mathf.Abs(transform.position.x - originalXPos) > range) 
			GameObject.Destroy (gameObject);

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
