using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	public float speed, minX, minY, maxX, maxY;
	private Rigidbody2D rb;
	private SpriteRenderer spriteRen;

	private CapsuleCollider2D hitbox;
	private Animator anim;

	//private CapsuleCollider2D hitbox;
	private DudeAttack child;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		spriteRen = GetComponent<SpriteRenderer>();

		hitbox = GetComponent<CapsuleCollider2D>();
		anim = GetComponent<Animator>();

		//hitbox = GetComponent<CapsuleCollider2D>();
		child = GetComponentInChildren<DudeAttack>();
	}

	void Update() {
		Vector2 pos = rb.position;
		pos.x = Mathf.Clamp (pos.x, minX, maxX);
		pos.y = Mathf.Clamp (pos.y, minY, maxY);
		rb.position = pos;

		if (Input.GetKeyDown (KeyCode.Space)) {
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


	}

	void spinToWin() {
		anim.SetTrigger("Attack");
	}

	void EnableChild () {
		child.enableHitbox();
	}

	void DisableChild () {
		child.disableHitbox();
		anim.ResetTrigger("Attack");
	}
}
