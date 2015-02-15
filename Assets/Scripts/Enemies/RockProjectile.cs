using UnityEngine;
using System.Collections;

public class RockProjectile : MonoBehaviour 
{
	
	public bool goRight;
	public float speed = 100f;
	private bool hitGround = false;
	public bool seen = false;
	void Start () {
	}
	
	void Update () {
		if (renderer.isVisible) seen = true;
		if (seen && !renderer.isVisible)
		{
			GameObject.Destroy (gameObject);
		}

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

