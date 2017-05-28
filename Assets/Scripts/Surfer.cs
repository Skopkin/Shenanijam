﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surfer : MonoBehaviour {

	public float speed;
	//private Player player;
	private float orgY, sinSpeed, amp;
	private float direction;
	private float force;
	private Rigidbody2D rb;
	public int enemyValue;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		//player = FindObjectOfType<Player> ();
		orgY = transform.localPosition.y;
		sinSpeed = Random.Range (1f, 6f);
		amp = Random.Range (0.7f, 1f);
		if (rb.position.x > 0)
			direction = -1;
		else
			direction = 1;
		
		force = speed * direction;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		rb.AddForce(new Vector2(force, 0.0f));
		transform.localPosition = new Vector2 (transform.localPosition.x, (orgY + amp * Mathf.Sin(sinSpeed*Time.time)));
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "Floater")
			Physics2D.IgnoreCollision (coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}
}
