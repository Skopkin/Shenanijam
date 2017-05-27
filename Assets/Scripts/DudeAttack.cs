using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeAttack : MonoBehaviour {

	private CircleCollider2D self;
	// Use this for initialization
	void Start () {
		self = GetComponent<CircleCollider2D> ();	
		disableHitbox ();
	}
	
	// Update is called once per frame
	public void enableHitbox () {
		self.enabled = true;
	}

	public void disableHitbox() {
		self.enabled = false;
	
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Obstacle") {
			Destroy (coll.gameObject);
		}
	}
}
