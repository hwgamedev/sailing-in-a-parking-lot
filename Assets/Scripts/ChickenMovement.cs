﻿using UnityEngine;
using System.Collections;

public class ChickenMovement : MonoBehaviour {

	public Vector2 moving = new Vector2();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moving.x = moving.y = 0;

		if (Input.GetKey("right"))
		{
			moving.x = 1;
		}
		else if (Input.GetKey("left"))
		{
			moving.x = -1;
		}
		
		if (Input.GetKey("up"))
		{
			moving.y = 1;
		}
		else if (Input.GetKey("down"))
		{
			moving.y = -1;
		}
		if(System.Math.Abs (Input.acceleration.x*90) > 15)
			moving.x = System.Math.Sign (Input.acceleration.x);
		if (Input.touchCount > 0) {
			moving.y = 1;
		}


	}
}
