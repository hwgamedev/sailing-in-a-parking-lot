using UnityEngine;
 using System.Collections;
 
public class Drag : MonoBehaviour {
	public GameObject combiner;
	public bool draggingObject;

     private Vector3 screenPoint;
     private Vector3 offset;
     Vector3 curScreenPoint;
     public Vector3 orginalPos;
    //private bool moved = false;

     void OnMouseDown()
     {
             offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

             draggingObject = true;
     }

     void OnMouseDrag()
     {
             curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
             Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
             transform.position = curPosition;

		      draggingObject = true;
              print(gameObject.name);

     }

	void OnMouseUpAsButton() {
		draggingObject = false;
        transform.localPosition = orginalPos;

	}

     void Update()
     {
     }

     void Start()
     {
         orginalPos = transform.localPosition;
     }
 }