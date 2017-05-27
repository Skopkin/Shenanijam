using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	public float speed, minX, minY, maxX, maxY;
	private float tempSpeed;
	private int hp;
	private Rigidbody2D rb;
	private SpriteRenderer spriteRen;
	private Animator anim;
	private DudeAttack child;
	private Slider meter;
	private GameObject heart1, heart2, heart3;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		spriteRen = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		child = GetComponentInChildren<DudeAttack>();
		meter = FindObjectOfType<Slider>();
		heart1 = GameObject.Find ("Heart1");
		heart2 = GameObject.Find ("Heart2");
		heart3 = GameObject.Find ("Heart3");
		heart1.SetActive (true);
		heart2.SetActive (true);
		heart3.SetActive (true);
		hp = 3;
		meter.value = 1;
		tempSpeed = speed;
	}

	void Update() {
		Vector2 pos = rb.position;
		pos.x = Mathf.Clamp (pos.x, minX, maxX);
		pos.y = Mathf.Clamp (pos.y, minY, maxY);
		rb.position = pos;

		if (Input.GetKeyDown (KeyCode.Space) && meter.value >= 0.1f && Time.timeScale != 0) {
			meter.value -= 0.1f;
			spinToWin ();
		}
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb.AddForce (movement * speed);
		if (Input.GetKey(KeyCode.A) && !Input.GetKey (KeyCode.D)) {
			spriteRen.flipX = true;
		} else if (Input.GetKey (KeyCode.D) && !Input.GetKey(KeyCode.A)) {
			spriteRen.flipX = false;
		}

		meter.value += Time.deltaTime * 0.02f;
	}

	void spinToWin() {
		anim.SetTrigger("Attack");
	}

	void EnableChild () {
		child.enableHitbox();
		speed *= 2f;
	}

	void DisableChild () {
		speed = tempSpeed;
		child.disableHitbox();
		anim.ResetTrigger("Attack");
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Obstacle") {
			Vector2 pushback = (transform.position - coll.gameObject.transform.position).normalized;
			rb.AddForce(pushback * (speed * 25));
			ReduceHearts ();
			
		} else if (coll.gameObject.tag == "Floater") {
			if (hp < 3 && hp > 0) {
				IncreaseHearts ();
				Destroy (coll.gameObject);
			} else {
				Physics2D.IgnoreCollision (coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			}
		}
	}

	void IncreaseHearts() {
		hp++;
		switch (hp) {
		case 2:
			heart2.SetActive (true);
			break;
		case 3:
			heart3.SetActive (true);
			break;
		}
	}

	void ReduceHearts() {
		hp--;
		switch (hp) {
		case 0:
			heart1.SetActive (false);
			break;
		case 1:
			heart2.SetActive (false);
			break;
		case 2:
			heart3.SetActive (false);
			break;
		}
	}

	public int getHP() {
		return hp;
	}
}
