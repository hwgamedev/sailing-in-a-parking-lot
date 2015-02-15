using UnityEngine;
using System.Collections;

public class WaterGuard : MonoBehaviour {

	private GuardCheck guard;
	public float vanishTime = 3f;

	void Start()
	{
		guard = gameObject.GetComponent<GuardCheck>();
	}

	void Update ()
	{
	}

	void Teleport() 
	{
		if (guard.sawPlayer)
		{

		}
	}

	
}

