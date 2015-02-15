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
    private SpriteRenderer spriteRenderer;
    private MagicCombiner magic;
	
	// Use this for initialization
	void Start () {
		swipeComponent = GetComponent<swipe> ();
        magic = FindObjectOfType(typeof(MagicCombiner)) as MagicCombiner;
	}
	
	// Update is called once per frame
	void Update () {
		if(weaponInstance) {
			//instanceSpeed += weaponSpeed;
			rotation += instanceSpeed*-1*weaponDirection;

			//print (rotation);
			//weaponInstance.transform.RotateAround(transform.position, Vector3.back, rotation*Time.deltaTime);

			Quaternion rot = weaponInstance.transform.rotation;
			rot.z = Mathf.Deg2Rad*rotation;
			weaponInstance.transform.position = transform.position;
			weaponInstance.transform.rotation = rot;

			//print (weaponInstance.transform.localEulerAngles.z);
			if(Mathf.Abs(weaponInstance.transform.localEulerAngles.z) < 210 && weaponDirection == 1) {
				Destroy(weaponInstance);
			}
			else if(Mathf.Abs(weaponInstance.transform.localEulerAngles.z) > 150 && weaponDirection == -1) {
				Destroy(weaponInstance);
			}
		}
		else {
			if(swipeComponent.left || swipeComponent.right || Input.GetKey ("space")) {
				weaponDirection = GetComponent<ChickenMovement>().facingDirection;
				print (weaponDirection);
				createWeapon();
			}
		}
	}
	
	void createWeapon() {
		weaponInstance = Instantiate(weaponTemplate, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
        //weaponInstance.transform.parent = transform;
        rotation = 0;
		instanceSpeed = weaponSpeed;
        spriteRenderer = weaponInstance.GetComponent<SpriteRenderer>();
        spriteRenderer.color = magicColor();

	}

    Color magicColor()
    {
        if(magic.earthOn && magic.attackOn)
    {
        return Color.green;
    }
        else if (magic.fireOn && magic.attackOn)
        {
            return Color.red;
        }
        else if (magic.windOn && magic.attackOn)
        {
            return Color.blue;
        }
        else
        {
            return spriteRenderer.color;
        }
    }
}
