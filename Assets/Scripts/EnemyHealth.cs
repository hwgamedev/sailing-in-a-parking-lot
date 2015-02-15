using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public GameObject healthBarTemplate;
	public float maxHealth = 50;

	private float totalHealth;
	public float blinkyTime = 0.2f;

	private float blinkyElapsed;
	private Color originalColor;
	private SpriteRenderer sr;
	private GameObject healthBar;

	// Use this for initialization
	void Start () {
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
		}
		Vector3 htransform = healthBar.transform.position;
		htransform.x = transform.position.x;
		htransform.y = transform.position.y + 1;
		healthBar.transform.position = htransform;


	}

    public void dealDamage(float amount, float knockback)
    {
        totalHealth -= amount;
        blinkyElapsed = 0;

        //bounceback
        rigidbody2D.AddForce(new Vector2(knockback, 5f), ForceMode2D.Impulse);
        healthBar.GetComponentInChildren<EnemyHealthBar>().updatePercentage(totalHealth / maxHealth * 1.0f);

        if (totalHealth < 0)
        {
            GetComponent<DropItem>().dropItem();
            if (totalHealth <= 0)
            {
                Destroy(healthBar);
                Destroy(gameObject);

            }
        }
    }

    public float healthRemaining()
    {
        return totalHealth;
    }
}
