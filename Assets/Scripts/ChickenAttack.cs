using UnityEngine;
using System.Collections;

public class ChickenAttack : MonoBehaviour {

	public GameObject weaponTemplate;
	public float weaponSpeed;
	
	private GameObject weaponInstance;
	private float rotation;
	private float instanceSpeed;
	private swipe swipeComponent;
	private float weaponDirection;
	
	// Use this for initialization
	void Start () {
		swipeComponent = GetComponent<swipe> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(weaponInstance) {
			//instanceSpeed += weaponSpeed;
			rotation += instanceSpeed*weaponDirection*-1;
			//print (rotation);
			//weaponInstance.transform.RotateAround(transform.position, Vector3.back, rotation*Time.deltaTime);
			weaponInstance.transform.Rotate (new Vector3(0,0,Mathf.Deg2Rad*rotation));
			print (weaponInstance.transform.localEulerAngles.z);
			if(weaponDirection == -1 && Mathf.Abs(weaponInstance.transform.localEulerAngles.z) > 150) {
				Destroy (weaponInstance);
			}
			if(weaponDirection == 1 && Mathf.Abs(weaponInstance.transform.localEulerAngles.z) < 210) {
				Destroy(weaponInstance);
			}
		}
		else {
			if(swipeComponent.left || swipeComponent.right || Input.GetKey ("space")) {
				weaponDirection = transform.localScale.x;
				print (weaponDirection);
				createWeapon();
			}
		}
	}
	
	void createWeapon() {
		weaponInstance = Instantiate(weaponTemplate, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
        weaponInstance.transform.parent = transform;
        rotation = 0;
		instanceSpeed = weaponSpeed;

	}
}
