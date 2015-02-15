using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour {

	public GameObject itemTemplate;
	public float probability;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void dropItem() {
		if(Random.Range (0f,1f) < probability) {
			GameObject item = Instantiate(itemTemplate, new Vector3(transform.position.x, transform.position.y+1, 0), Quaternion.identity) as GameObject;
			item.rigidbody2D.AddForce (new Vector2 (0, 1.5f), ForceMode2D.Impulse);
		}
	}
}
