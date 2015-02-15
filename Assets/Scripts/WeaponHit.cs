using UnityEngine;
using System.Collections;

public class WeaponHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy") {
			int direction = 0;
			if (transform.rotation.z * Mathf.Rad2Deg > 180)
				direction = 1;
			else
				direction = -1;

			float knockback = 5f;
			//Extend damage here
			col.gameObject.GetComponent<EnemyHealth> ().dealDamage (10,knockback*direction);

		}
	}
}
