using UnityEngine;
using System.Collections;

public class RockProjectile : MonoBehaviour 
{
	
	public bool goRight;
	private float originalXPos;
	public float speed = 100f;
	public float range = 20f;
	private bool hitGround = false;
	void Start () {
		originalXPos = transform.position.x;
	}
	
	void Update () {
		if (Mathf.Abs(transform.position.x - originalXPos) > range) 
			GameObject.Destroy (gameObject);
		if (hitGround)
			ForceApply();
		
	}
	
	void ForceApply ()
	{
		if (goRight)
			rigidbody2D.AddForce(Vector3.right * speed);
		else
			rigidbody2D.AddForce(Vector3.left * speed);
	}
	
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
			GameObject.Destroy (gameObject);
		else 
			hitGround = true;
	}
}

