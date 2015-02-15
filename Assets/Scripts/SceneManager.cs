using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public float timeToChange = 3f;
	private float timer;
	public bool changeScene = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (changeScene)
		{
			timer-=Time.deltaTime;
			if (timer <= 0)
				Application.LoadLevel("GameOver");
		}

	}

	public void ChangeScene()
	{
		changeScene = true;
		timer = timeToChange;
	}

	public void gameWon()
	{
		Application.LoadLevel("GameWon");
	}


}
