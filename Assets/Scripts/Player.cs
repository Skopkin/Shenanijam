using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	private SpriteRenderer spriteRen;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		spriteRen = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb.AddForce (movement * speed);
		if (movement.x < 0) {
			spriteRen.flipX = true;
		} else {
			spriteRen.flipX = false;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			spinToWin ();
		}
	}

	void spinToWin() {
		Debug.Log ("Attack");
	}
}
