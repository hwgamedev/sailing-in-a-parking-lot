using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

	public float invincibilityTime = 3;
		
	private float invincibilityRemaining;
	private int health = 3;
	private SpriteRenderer sr;
	private float blinkyInterval;
	private float blinkyIntervalMax = 0.1f;
	private HeartManager hm;
    private GameObject[] chunks = new GameObject[6];

	public bool incHealth() {
		if (health < 3) {
			health++;
			hm.updateHearts(health);
			return true;
		}
		return false;
	}
	
	public int getHealth() { return health; }

	// Use this for initialization
	void Start () {
        chunks = Resources.LoadAll<GameObject>("Prefabs/Explode");
		hm = GameObject.FindGameObjectWithTag ("healthbar").GetComponent<HeartManager> ();
		invincibilityRemaining = invincibilityTime;
		sr = GetComponent<SpriteRenderer> ();
		blinkyInterval = blinkyIntervalMax;
	}
	
	// Update is called once per frame
	void Update () {
        if (health ==0)
        {
            die();
        }
		if(invincibilityRemaining > 0) {
			invincibilityRemaining -= Time.deltaTime;
			Color c = sr.color;
			blinkyInterval -= Time.deltaTime;
			if(blinkyInterval < 0) {
				c.a = c.a == 1.0f? 0.2f : 1.0f;
				blinkyInterval = blinkyIntervalMax;
			}
			sr.color = c;
		}
		else {
			invincibilityRemaining = 0;
			Color c = sr.color;
			c.a = c.a == 0.2f? 1.0f : 1.0f;
			sr.color = c;
		}
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Enemy" || col.gameObject.tag == "Projectile") && health > 0 && invincibilityRemaining == 0)
        {
            if (col.gameObject.tag == "Enemy" && health > 0 && invincibilityRemaining == 0)
            {
                health--;
                hm.updateHearts(health);
                invincibilityRemaining = invincibilityTime;
                float xDirection = System.Math.Sign(rigidbody2D.velocity.x);
                rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
        }
    }

	public bool incHealth() {
		if (health < 3) {
			health++;
			hm.updateHearts(health);
			return true;
		}
		return false;
	}

	public int getHealth() { return health; }

    public void die()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            print("Chunk");
            GameObject chunk = Instantiate(chunks[i], transform.position, Quaternion.identity) as GameObject;
            chunks[i].rigidbody2D.AddForce(Vector3.right * Random.Range(-25, 25));
            chunks[i].rigidbody2D.AddForce(Vector3.up * Random.Range(50, 200));
        }
        Destroy(gameObject);
        
    }
	void OnCollisionEnter2D(Collision2D col) {
		if ((col.gameObject.tag == "Enemy" || col.gameObject.tag == "Projectile") && health > 0 && invincibilityRemaining == 0) {
			health--;
			hm.updateHearts(health);
			invincibilityRemaining = invincibilityTime;
			float xDirection = System.Math.Sign (rigidbody2D.velocity.x);
			rigidbody2D.AddForce (new Vector2(0,5),ForceMode2D.Impulse);
		}
	}
}
