using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour {

	public float xForce;
	public float yForce;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		rb.AddForce(new Vector2(xForce, yForce));
	}
}
