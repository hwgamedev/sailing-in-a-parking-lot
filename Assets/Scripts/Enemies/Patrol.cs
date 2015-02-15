using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {
	public float maxSpeed = 1f;
	public bool facingRight = true;
	public float moveRadius = 10f;
	public bool startToRight = true;
	private float lastXPos;

	public Vector2 left, right;

	void Start () {

		if ((startToRight && !facingRight) || (!startToRight && facingRight))
			Flip ();

		left = new Vector2 (rigidbody2D.position.x - moveRadius, rigidbody2D.position.y);
		right = new Vector2 (rigidbody2D.position.x + moveRadius, rigidbody2D.position.y);
		lastXPos = rigidbody2D.position.x ;
	}

	void Update () {
		if ((rigidbody2D.position.x <= left.x && !facingRight) || (rigidbody2D.position.x >= right.x && facingRight))
			Flip ();



		float step = maxSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(rigidbody2D.position, new Vector3(facingRight?right.x:left.x, rigidbody2D.position.y, transform.position.z), step);
		if (Mathf.Abs(lastXPos - rigidbody2D.position.x)<0.003)
			Flip ();

		lastXPos = rigidbody2D.position.x;
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

}
