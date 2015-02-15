using UnityEngine;
using System.Collections;

public class swipe : MonoBehaviour {

	private bool swiping = false;
	private bool eventSent = false;
	private Vector2 lastPosition;
	public bool up, down, left, right;
	
	void Update () {
		up = down = left = right = false;
		//Debug.Log ("a");
		if (GetComponent<ChickenMovement> ().noDragged != 0)
			return;

		if (Input.touchCount == 0) 
			return;
		
		if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0){
			//Debug.Log ("b");
			if (swiping == false){
				swiping = true;
				lastPosition = Input.GetTouch(0).position;
				return;
			}
			else{
				//Debug.Log ("c");
				if (!eventSent) {
					Vector2 direction = Input.GetTouch(0).position - lastPosition;
					
					if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
						if (direction.x > 0) 
							right = true;
						else
							left = true;
					}
					else{
						if (direction.y > 0)
							up = true;
						else
							down = true;
					}
					
					eventSent = true;
				}
			}
		}
		else{
			swiping = false;
			eventSent = false;
		}
	}
}