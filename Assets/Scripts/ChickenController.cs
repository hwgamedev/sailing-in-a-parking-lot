using UnityEngine;
using System.Collections;

public class ChickenController : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	public float jumpSpeed = 15f;    
	public float airSpeedMultiplier = .3f;
	public bool standing;
	private ChickenMovement controller;
	private Animator animator;


	// Use this for initialization
	void Start () {        
		controller = GetComponent<ChickenMovement>();
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	
		var forceX = 0f;
		var forceY = 0f;
		
		var absVelocityX = Mathf.Abs(rigidbody2D.velocity.x);
		var absVelocityY = Mathf.Abs(rigidbody2D.velocity.y);
		
		if (absVelocityY < 0.2f)
		{
			standing = true;
		}
		else
		{
			standing = false;
		}
		
		if (controller.moving.x != 0)
		{
			if (absVelocityX < maxVelocity.x)
			{
				forceX = standing ? (speed * controller.moving.x) : (speed * controller.moving.x * airSpeedMultiplier);
				
				transform.localScale = new Vector3(forceX > 0 ? 1 : -1, 1, 1);
			}
			animator.SetInteger("animState", 1);
		}
		else
		{
			animator.SetInteger("animState", 0);
		}
		
		if (controller.moving.y > 0 && standing)
		{
			if (absVelocityY < maxVelocity.y)
			{
				forceY = jumpSpeed * controller.moving.y;
				rigidbody2D.AddForce(new Vector2(0, forceY), ForceMode2D.Impulse);

			}
			animator.SetInteger("animState", 2);
		}
		else if (absVelocityY > 0)
		{
			animator.SetInteger("animState", 3);
		}
		
		rigidbody2D.AddForce(new Vector2(forceX, 0));
	}
}
