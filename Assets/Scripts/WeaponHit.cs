using UnityEngine;
using System.Collections;

public class WeaponHit : MonoBehaviour {
    private MagicCombiner magic;
	// Use this for initialization
	void Start () {
        magic = FindObjectOfType(typeof(MagicCombiner)) as MagicCombiner;
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

			float knockback = 500f;
			//Extend damage here
            if (magic.attackOn)
            {
                float health = col.gameObject.GetComponent<EnemyHealth>().healthRemaining();
                if (magic.fireOn)
                {
                    col.gameObject.GetComponent<EnemyHealth>().dealDamage(health, knockback * direction);
                    print(health);
                }
                else if (magic.windOn)
                {
                    col.gameObject.GetComponent<EnemyHealth>().dealDamage(10, knockback*4 * direction);
                }
                else if (magic.earthOn)
                {
                    if (magic.earthOn)
                    {
                        col.gameObject.GetComponent<EnemyHealth>().dealDamage(health/2.0f + 5, knockback*2.0f * direction);
                    }
                }
            }
            else
            {
                col.gameObject.GetComponent<EnemyHealth>().dealDamage(10, knockback * direction);
            }
		}
	}
}
