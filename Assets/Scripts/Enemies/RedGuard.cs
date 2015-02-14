using UnityEngine;
using System.Collections;

public class RedGuard : MonoBehaviour {

	public float sightDistance = 30f;
	public bool sawPlayer;

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
		sawPlayer = Physics.Raycast( transform.position,Vector3.right, sightDistance);
	}

	void DebugRays()
	{
		Debug.DrawRay (transform.position,Vector3.right, Color.red);
	}


}
