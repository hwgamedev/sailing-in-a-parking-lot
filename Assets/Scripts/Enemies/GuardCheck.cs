using UnityEngine;
using System.Collections;

public class GuardCheck : MonoBehaviour {

	public float sightDistance = 5f;
	public bool sawPlayer = false;
	public float lastXPos;
	//public Transform player;

	void Start()
	{

	}

	void Update()
	{
		CheckForPlayer();
		DebugRays();
	}

	void CheckForPlayer()
	{
		//RaycastHit2D hit;
		if (gameObject.GetComponent<Patrol>().facingRight){
			sawPlayer = Physics2D.Raycast(new Vector2(transform.position.x+1,transform.position.y - 0.5f ), Vector2.right, sightDistance,LayerMask.GetMask("Player"));
			if(!sawPlayer){
				sawPlayer = Physics2D.Raycast(new Vector2(transform.position.x+1,transform.position.y ), Vector2.right, sightDistance,LayerMask.GetMask("Player"));
				if(!sawPlayer)
					sawPlayer = Physics2D.Raycast(new Vector2(transform.position.x+1,transform.position.y + 0.5f ), Vector2.right, sightDistance,LayerMask.GetMask("Player"));
			}
		}else
			sawPlayer = Physics2D.Raycast(new Vector2(transform.position.x-1,transform.position.y - 0.5f ), -Vector2.right, sightDistance,LayerMask.GetMask("Player"));
			if(!sawPlayer){
				sawPlayer = Physics2D.Raycast(new Vector2(transform.position.x-1,transform.position.y ), -Vector2.right, sightDistance,LayerMask.GetMask("Player"));
				if(!sawPlayer)
					sawPlayer = Physics2D.Raycast(new Vector2(transform.position.x-1,transform.position.y + 0.5f ), -Vector2.right, sightDistance,LayerMask.GetMask("Player"));
			}
	}
	
	void DebugRays()
	{
		if (gameObject.GetComponent<Patrol>().facingRight){
			Debug.DrawRay (transform.position,Vector3.right * sightDistance, Color.red);
		}else
			Debug.DrawRay (transform.position,Vector3.left * sightDistance, Color.red);
	}


}
