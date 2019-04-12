using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public float timer, delayTimer;
	public GameObject car;

	void Start () {
		spawn ();
	}

	void Update () {
		timer += Time.deltaTime;
		if (timer >= delayTimer) {
			spawn ();
			timer = 0;
		}
	}

	public void spawn()
	{
		float yPos = Random.Range (-2.5f, 3);
		Vector2 pos = new Vector2 (transform.position.x, yPos);
		GameObject go = Instantiate (car, pos, Quaternion.Euler(new Vector3(0,0,90)));
		Destroy (go, 1.0f);
	}
}
