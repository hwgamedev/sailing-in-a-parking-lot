using UnityEngine;
using System.Collections;

public class swipe : MonoBehaviour {

	private bool swiping = false;
	private bool eventSent = false;
	private Vector2 lastPosition;
	
	void Update () {
		Debug.Log ("a");
		if (Input.touchCount == 0) 
			return;
		
		if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0){
			Debug.Log ("b");
			if (swiping == false){
				swiping = true;
				lastPosition = Input.GetTouch(0).position;
				return;
			}
			else{
				Debug.Log ("c");
				if (!eventSent) {
					Vector2 direction = Input.GetTouch(0).position - lastPosition;
					
					if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
						if (direction.x > 0) 
							Debug.Log ("RIGHT");
						else
							Debug.Log ("LEFT");
					}
					else{
						if (direction.y > 0)
							Debug.Log ("UP");
						else
							Debug.Log ("DOWN");
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