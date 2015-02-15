using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour {

	public Image[] heartImages;

	private Stack<Image> hearts;
	private Stack<Image> disabledHearts;

	// Use this for initialization
	void Start () {
		hearts = new Stack<Image> ();
		for (int i =0; i < heartImages.Length; i++) {
			hearts.Push (heartImages[i]);
		}
		disabledHearts = new Stack<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void updateHearts(int health) {
		
		if (health > hearts.Count) {
			Image img = disabledHearts.Pop();
			img.GetComponent<Image>().enabled = true;
			hearts.Push (img);
		} else if(health < hearts.Count) {
			Image img = hearts.Pop();
			img.GetComponent<Image>().enabled = false;
			disabledHearts.Push (img);
		}
	}
}
