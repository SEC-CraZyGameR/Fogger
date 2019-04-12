using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FogMovement : MonoBehaviour {

	private Rigidbody2D rigidbody;
	private bool isDied = false;
	public GameObject panel;
	public Text gameEndText;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Update () {

		if (!isDied)
			move ();
	}
	public void move()
	{
		if (Input.GetKeyDown (KeyCode.D)) {
			rigidbody.MovePosition (rigidbody.position+Vector2.right);
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			rigidbody.MovePosition (rigidbody.position+Vector2.left);
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			rigidbody.MovePosition (rigidbody.position+Vector2.up);
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			rigidbody.MovePosition (rigidbody.position+Vector2.down);
		}
	}
	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("car")) {
			//Debug.Log ("Triggered");
			isDied = true;
			GetComponent<SpriteRenderer> ().color = Color.red;
			gameEndText.text = "Game Over";
			panel.SetActive (true);
		}
		if (col.CompareTag ("win")) {
			//Debug.Log ("You Win");
			isDied = true;
			panel.SetActive (true);
			gameEndText.text = "You Win";
		}
	}
	public void reStart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
