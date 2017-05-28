using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "Projectile")
			Destroy (coll.gameObject);
	}
}
