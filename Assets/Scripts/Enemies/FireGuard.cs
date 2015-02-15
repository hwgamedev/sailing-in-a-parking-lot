using UnityEngine;
using System.Collections;

public class FireGuard : MonoBehaviour {

	public GameObject fireball;
	private GuardCheck guard;
	private Patrol patrol;
	public int projectileNo = 3;
	public float shootDelay = 3f;
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
			GameObject [] clone = new GameObject[projectileNo];

			for (int i = 0; i< projectileNo; i++)
			{
				if (patrol.facingRight)
					clone[i] = Instantiate(fireball, new Vector3(transform.position.x + 1, transform.position.y, 0), transform.rotation) as GameObject;
				else
					clone[i] = Instantiate(fireball, new  Vector3(transform.position.x - 1, transform.position.y, 0), transform.rotation) as GameObject;

				clone[i].GetComponent<Projectile>().goRight = patrol.facingRight;
			}
			timeToShoot = shootDelay;
		}
	}



}
