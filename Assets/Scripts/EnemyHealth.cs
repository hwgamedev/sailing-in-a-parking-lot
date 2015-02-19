using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public GameObject healthBarTemplate;
	public float maxHealth = 50;
    public string chunkfolder;

	private float totalHealth;
	public float blinkyTime = 0.2f;

	private float blinkyElapsed;
	private Color originalColor;
	private SpriteRenderer sr;
	private GameObject healthBar;
    private GameObject[] chunks = new GameObject[3];

    //knockback reversal
    private float knockback;

	// Use this for initialization
	void Start () {
        chunks = Resources.LoadAll<GameObject>("Prefabs/" + chunkfolder);
		totalHealth = maxHealth;
		blinkyElapsed = -1;
		sr = GetComponent<SpriteRenderer> ();
		healthBar = Instantiate(healthBarTemplate, new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.identity) as GameObject;

	}
	
	// Update is called once per frame
	void Update () {
		if (blinkyElapsed == 0) {
			Color tmp = sr.color;
			originalColor = tmp;
			sr.color = Color.red;
		}
		if(blinkyElapsed != -1)
			blinkyElapsed += Time.deltaTime;
		if (blinkyElapsed >= blinkyTime) {
			sr.color = originalColor;
            blinkyElapsed = -1;
            rigidbody2D.AddForce(new Vector2(-knockback, 0f), ForceMode2D.Impulse);

		}
		Vector3 htransform = healthBar.transform.position;
		htransform.x = transform.position.x;
		htransform.y = transform.position.y + 1;
		healthBar.transform.position = htransform;


	}

    public void dealDamage(float amount, float knockbackForce)
    {
        totalHealth -= amount;
        blinkyElapsed = 0;
        if (totalHealth <= 0)
        {

			die();

        }
        knockback = knockbackForce;

        //bounceback
        rigidbody2D.AddForce(new Vector2(knockback, 0f), ForceMode2D.Impulse);
        healthBar.GetComponentInChildren<EnemyHealthBar>().updatePercentage(totalHealth / maxHealth * 1.0f);


    }

	void OnCollisionEnter2D(Collision2D col)
	{
	
		if (col.gameObject.tag == "Cage") {
			die ();
		}
	}

	private void die() {
		explode();
		GetComponent<DropItem>().dropItem();
		Destroy(healthBar);
		Destroy(gameObject);
	}

    public float healthRemaining()
    {
        return totalHealth;
    }

    public void explode()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject chunk = Instantiate(chunks[i], transform.position, Quaternion.identity) as GameObject;
            chunk.rigidbody2D.AddForce(Vector3.right * Random.Range(-25, 25));
            chunk.rigidbody2D.AddForce(Vector3.up * Random.Range(50, 200));
        }
    }
}
