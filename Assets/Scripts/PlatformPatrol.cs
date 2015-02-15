using UnityEngine;
using System.Collections;

public class PlatformPatrol : MonoBehaviour {
	public float maxSpeed = 1f;
	public float moveRadius = 10f;
	float origin = 0f;
	public bool startToRight = true;
	float move;
	public bool horizontal = true;
	
	void Start () {
		if (startToRight)
			move = 1;
		else
			move = -1;
		if (horizontal) {
			origin = rigidbody2D.position.x;
		} else {
			origin = rigidbody2D.position.y;
		}
	}
	
	void Update () {
		if (horizontal) {
			if(rigidbody2D.position.x > origin+moveRadius){
				rigidbody2D.position = new Vector2(origin+moveRadius, rigidbody2D.position.y);
				move = -1;
			} else if(rigidbody2D.position.x < origin-moveRadius){
				rigidbody2D.position = new Vector2(origin-moveRadius, rigidbody2D.position.y);
				move = 1;
			}
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		} else {
			if(rigidbody2D.position.y > origin+moveRadius){
				rigidbody2D.position = new Vector2(rigidbody2D.position.x ,origin+moveRadius);
				move = -1;
			} else if(rigidbody2D.position.y < origin-moveRadius){
				rigidbody2D.position = new Vector2(rigidbody2D.position.x ,origin-moveRadius);
				move = 1;
			}
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move * maxSpeed);
		}
	}
	
}