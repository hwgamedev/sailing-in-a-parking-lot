using UnityEngine;
using System.Collections;

public class ChickenMovement : MonoBehaviour {

	public Vector2 moving = new Vector2();
	public float facingDirection = 1;
	public int noDragged = 0;

    private bool jumped = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moving.x = moving.y = 0;

		//check if any tokens are being dragged about at the moment
		noDragged = 0;
		GameObject[] draggables = GameObject.FindGameObjectsWithTag ("Draggable");
		for(int i = 0; i < draggables.Length; i++) {
			if(draggables[i].GetComponent<Drag>().draggingObject)
				noDragged++;
		}
		if (noDragged != 0) {
			return;

		}

		if (Input.GetKey("right"))
		{
			moving.x = 1;
			facingDirection = 1;
		}
		else if (Input.GetKey("left"))
		{
			moving.x = -1;
			facingDirection = -1;
		}
		
		if (Input.GetKey("up"))
		{
			moving.y = 1;
		}
		else if (Input.GetKey("down"))
		{
			moving.y = -1;
		}
		if(System.Math.Abs (Input.acceleration.x*90) > 15) {
			moving.x = System.Math.Sign (Input.acceleration.x);
			facingDirection = moving.x;
		}

        if (Input.touchCount > 0)
        {
            if (!jumped)
            {
                moving.y = 1;
                jumped = true;
                
            }

        }
        if(Input.touchCount == 0)
        {
            jumped = false;
        }

	}
}
