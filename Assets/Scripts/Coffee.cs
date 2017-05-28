using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour {

	public float xForce;
	public float yForce;
	public float value;
	private Rigidbody2D rb;
	private Player player;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<Player> ();

	}

	void FixedUpdate() {
		rb.AddForce(new Vector2(xForce, yForce));
		if (rb.position.y >= player.maxY)
			fadeAway ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" && (player.getEnergy() < 1f)) {
			player.IncreaseEnergy (value);
			Destroy (this.gameObject);
		}
	}

	void fadeAway () {
		rb.transform.localScale *= 0.85f;
		if (rb.transform.localScale.x <= 0)
			Destroy (this.gameObject);
	}
}