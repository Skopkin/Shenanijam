using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour {


	private Rigidbody2D rb;
	private float direction, force, shitRate;
	public float speed;
	public GameObject shit;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		if (rb.position.x > 0)
			direction = -1;
		else
			direction = 1;

		force = speed * direction;
		shitRate = Random.Range (2f, 3.5f);

		StartCoroutine (Timer());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce(new Vector2(force, 0.0f));
	}

	IEnumerator Timer() {
		while (true) {
			yield return new WaitForSeconds (shitRate);
			TakeABigFatDump ();
		}
	}

	void TakeABigFatDump() {
		Vector2 spawnPosition = new Vector2 (rb.transform.position.x, rb.transform.position.y);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (shit, spawnPosition, spawnRotation);

	}
}
