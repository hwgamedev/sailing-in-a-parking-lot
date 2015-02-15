using UnityEngine;
using System.Collections;

public class WaterGuard : MonoBehaviour {

	private GuardCheck guard;
	public Transform player;
	public float vanishTime = 1f;
	public float waitTime = 5f;
	public bool vanishing = false;
	public bool appearing = false;
	public bool waiting = false;
	private float vanishTimer = 0f;
	private float waitTimer = 0f;
	public float minDistanceToPlayer = 0.1f;
	public float maxDistanceToPlayer = 5f;

	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
		guard = gameObject.GetComponent<GuardCheck>();
		Physics2D.IgnoreLayerCollision(16,5);
	}

	void Update ()
	{
		Teleport ();
		SetAnimatorParameters();
	}

	void Teleport() 
	{
		if (vanishing)
		{
			vanishTimer -= Time.deltaTime;
			if (vanishTimer <= 0)
			{
				vanishing = false;
				float posDelta;
				if(Random.Range(0,2) == 0)
				{
					posDelta = Random.Range (minDistanceToPlayer, maxDistanceToPlayer);
				}else
					posDelta = Random.Range (-maxDistanceToPlayer, -minDistanceToPlayer);
				rigidbody2D.position = new Vector2(player.position.x + posDelta , player.position.y);
				appearing = true;
				vanishTimer = vanishTime;
			}

		}else
			if(appearing)
			{
				vanishTimer -= Time.deltaTime;
				if (vanishTimer <= 0)
				{
					appearing = false;
					waiting = true;
					waitTimer = waitTime;
				}
			}else 
				if (waiting)
				{
					waitTimer -=Time.deltaTime;
					if (waitTimer <= 0)
					{
						waiting = false;
						vanishing = true;
						vanishTimer = vanishTime;
					}
				}else 
					if (guard.sawPlayer)
					{
						vanishing = true;
						vanishTimer = vanishTime;
					}
	}

	void SetAnimatorParameters()
	{
		animator.SetBool ("Vanishing", vanishing);
		animator.SetBool ("Appearing", appearing);
		animator.SetBool ("Waiting", waiting);

	}

	
}

