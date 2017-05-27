using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Obstacle")
			Destroy (coll.gameObject);
	}
}
