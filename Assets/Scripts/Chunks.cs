using UnityEngine;
using System.Collections;

public class Chunks : MonoBehaviour {
    float timer = 2.0f;
	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
Destroy(gameObject);
        }
	}

}
