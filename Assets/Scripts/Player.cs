using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	public float speed, minX, minY, maxX, maxY;
	private float tempSpeed;
	private Rigidbody2D rb;
	private SpriteRenderer spriteRen;
	private Animator anim;
	private DudeAttack child;
	private Slider meter;
	private RawImage heart;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		spriteRen = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		child = GetComponentInChildren<DudeAttack>();
		meter = FindObjectOfType<Slider>();

		meter.value = 1;
		tempSpeed = speed;
	}

	void Update() {
		Vector2 pos = rb.position;
		pos.x = Mathf.Clamp (pos.x, minX, maxX);
		pos.y = Mathf.Clamp (pos.y, minY, maxY);
		rb.position = pos;

		if (Input.GetKeyDown (KeyCode.Space) && meter.value >= 0.1f) {
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
			
		} else if (coll.gameObject.tag == "Pickup") {
			Pickup ();
		}
	}

	void Pickup() {

	}

}
