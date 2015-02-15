using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public GameObject weaponTemplate;
	public float weaponSpeed;

	private GameObject weaponInstance;
	private float rotation;
	private float instanceSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(weaponInstance) {
			instanceSpeed *= weaponSpeed;
			rotation += instanceSpeed;
			weaponInstance.transform.RotateAround(transform.position, new Vector3(1,0,0), rotation);
			if(rotation > 100) {
				Destroy (weaponInstance);
			}
		}
	}

	void OnEnterCollision2D(Collider2D col) {
		if(col.collider.tag == "Enemy") {
			weaponInstance = Instantiate(weaponTemplate, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity) as GameObject;
			rotation = 0;
			instanceSpeed = weaponSpeed;
		}
	}
}
