using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class skyManager : MonoBehaviour {

	public Transform skyline1;
	public Transform skyline2;
	public Transform skyline3;
	public Transform skyline4;
	public int numberOfSkyline;
	private Vector2 startPos;
	private Vector2 nextPos;
	private Queue<Transform> skylineQueue;
	public float recycleOffset;
	public Camera cam;
	public float camMinBound;
	public float camMaxBound;

	// Use this for initialization
	void Start () {
		skylineQueue = new Queue<Transform>(numberOfSkyline);
		for (int i = 0; i < numberOfSkyline; i++) {
			Transform o = generate();
			Vector2 pos = new Vector2(i*Random.Range(5,10), Random.Range(0,4));
			o.localPosition = pos;
			skylineQueue.Enqueue(o);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (skylineQueue.Peek().localPosition.x+5 < camMinBound) {
			Recycle();
		} else {
			Transform o = skylineQueue.Dequeue();
			o.Translate(-3f * Time.deltaTime, 0f, 0f);
			skylineQueue.Enqueue(o);
		}
	}

	private void Recycle(){
		Transform p = skylineQueue.Dequeue();
		Destroy (p.gameObject);
		Transform o = generate ();
		Vector2 pos = new Vector2(camMaxBound+Random.Range(5,10), Random.Range(0,4));
		o.localPosition = pos;
		skylineQueue.Enqueue(o);
	}

	private Transform generate() {
		int rand = Random.Range(0,4);
		switch(rand){
		case 0 :
			return (Transform)Instantiate(skyline1);
		case 1 :
			return (Transform)Instantiate(skyline2);
		case 2 :
			return (Transform)Instantiate(skyline3);
		case 3 :
			return (Transform)Instantiate(skyline4);
		default :
			return (Transform)Instantiate(skyline1);
		}
	}
}
