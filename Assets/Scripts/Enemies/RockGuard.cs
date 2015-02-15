using UnityEngine;
using System.Collections;

public class RockGuard : MonoBehaviour {

	public GameObject rockProjectile;
	private GuardCheck guard;
	private Patrol patrol;
	public float shootDelay = 2f;
	private float timeToShoot = 0f;
	
	
	void Start () {
		guard = gameObject.GetComponent<GuardCheck>();
		patrol = gameObject.GetComponent<Patrol>();
		Physics2D.IgnoreLayerCollision(20,5);
	}
	
	void Update () {
		if (timeToShoot > 0)
			timeToShoot -=Time.deltaTime;
		else 
			ShootFire ();
	}
	
	void ShootFire()
	{	
		
		if (guard.sawPlayer)
		{
			Physics2D.IgnoreLayerCollision(19,19);
			Physics2D.IgnoreLayerCollision(19,16);
			Physics2D.IgnoreLayerCollision(19,5);
			GameObject  clone;

			clone = Instantiate(rockProjectile, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation) as GameObject;
			
			clone.GetComponent<RockProjectile>().goRight = patrol.facingRight;
			timeToShoot = shootDelay;
		}
	}
}
