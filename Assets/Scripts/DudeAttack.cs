using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeAttack : MonoBehaviour {

	private Collider2D self;
	public int enemyValue;
	public AudioClip wilhelm;
	public AudioSource audioSource;
	// Use this for initialization
	void Start () {
		self = GetComponent<Collider2D> ();	
		audioSource.clip = wilhelm;
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
			audioSource.Play ();
			Destroy (coll.gameObject);
		}
	}
}
