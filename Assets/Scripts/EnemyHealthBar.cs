using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {

	public float visibleTime = 2;
	public float blinkyTime = 0.2f;

	private float barPercentage = 1f;
	private float visibleTimer = 0f;
	private float blinkyTimer = 0f;

	private SpriteRenderer sr;
	private SpriteRenderer parentSr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		parentSr = GetComponentsInParent<SpriteRenderer> ()[1];
		Color tmp = sr.color;
		tmp.a = tmp.a == 0f ? 1f : 0f;
		sr.color = tmp;
		Color tmp2 = parentSr.color;
		tmp2.a = tmp2.a == 0f ? 1f : 0f;
		parentSr.color = tmp2;
	}
	
	// Update is called once per frame
	void Update () {
		if(visibleTimer > 0) {
			visibleTimer -= Time.deltaTime;

			if(blinkyTimer <= 0) {
				Color tmp = sr.color;
				tmp.a = tmp.a == 0f ? 1f : 0f;
				sr.color = tmp;
				Color tmp2 = parentSr.color;
				tmp2.a = tmp2.a == 0f ? 1f : 0f;
				parentSr.color = tmp2;
				blinkyTimer = blinkyTime;
			}

			blinkyTimer -= Time.deltaTime;

					
			if(visibleTimer <= 0) {
				visibleTimer = 0;
				blinkyTimer = 0;
				Color tmp = sr.color;
				tmp.a = 0f;
				sr.color = tmp;
				Color tmp2 = parentSr.color;
				tmp2.a = 0f;
				parentSr.color = tmp2;
			}
		}
	
	}

	public void updatePercentage(float newVal) {
		if (newVal < 0)
			barPercentage = 0;
		barPercentage = newVal;
		Vector3 scale = transform.localScale;
		scale.x = barPercentage;
		transform.localScale = scale;
		visibleTimer = visibleTime;
		blinkyTimer = blinkyTime;
	}
}
