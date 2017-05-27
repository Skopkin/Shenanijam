using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surfer : MonoBehaviour {

	public float speed;
	private float direction;
	private float force;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		if (rb.position.x > 0)
			direction = -1;
		else
			direction = 1;
		
		force = speed * direction;
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(new Vector2(force, 0.0f));
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Obstacle")
			Physics2D.IgnoreCollision (coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}
}
