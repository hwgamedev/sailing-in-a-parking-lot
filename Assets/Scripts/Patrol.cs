﻿using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {
	public float maxSpeed = 1f;
	public bool facingRight = true;
	public float moveRadius = 10f;
	float distanceToOrigin =0;
	public bool startToRight = true;
	float move;
	public bool flip = true;

	void Start () {
		if (startToRight)
			move = 1;
		else
			move = -1;
	}

	void Update () {
		if (distanceToOrigin > moveRadius)
			move = -1;
		else
			if (distanceToOrigin < -moveRadius)
				move = 1;
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		distanceToOrigin += move * maxSpeed;
		if (move < 0 && facingRight)
			Flip ();
		else
			if (move > 0 && !facingRight)
				Flip ();
	}

	void Flip ()
	{
		if (flip) {
			facingRight = !facingRight;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
	}

}
