using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	public float speed, minX, minY, maxX, maxY;
	private float tempSpeed;
	private int hp;
	private float xScale;
	public AudioSource heartSource;
	public AudioClip heartClip;
	public AudioSource ahhSource;
	public AudioClip AhhClip;
	public AudioSource ughSource;
	public AudioClip ughClip;
	private Rigidbody2D rb;
	private Animator anim;
	private DudeAttack child;
	private Slider meter;
	private GameObject heart1, heart2, heart3;
	private bool flippedSprite;
	private CapsuleCollider2D myCollider;
	private bool canAttack = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		child = GetComponentInChildren<DudeAttack>();
		meter = FindObjectOfType<Slider>();
		myCollider = GetComponent<CapsuleCollider2D>();
		heartSource.clip = heartClip;
		ahhSource.clip = AhhClip;
		ughSource.clip = ughClip;
		heart1 = GameObject.Find ("Heart1");
		heart2 = GameObject.Find ("Heart2");
		heart3 = GameObject.Find ("Heart3");
		heart1.SetActive (true);
		heart2.SetActive (true);
		heart3.SetActive (true);

		hp = 3;
		meter.value = 1;
		tempSpeed = speed;
		xScale = transform.localScale.x;
	}

	void Update () {
		Vector2 pos = rb.position;
		pos.x = Mathf.Clamp (pos.x, minX, maxX);
		pos.y = Mathf.Clamp (pos.y, minY, maxY);
		rb.position = pos;

		if (Input.GetKeyDown (KeyCode.Space) && meter.value >= 0.1f && Time.timeScale != 0 && canAttack) {
			spinToWin ();
		}

		if (flippedSprite) {
			transform.localScale = new Vector3 (-xScale, transform.localScale.y, transform.localScale.z);
		} else {
			transform.localScale = new Vector3 (xScale, transform.localScale.y, transform.localScale.z);
		}

	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb.AddForce (movement * speed);
		if (Input.GetKey(KeyCode.A) && !Input.GetKey (KeyCode.D)) {
			flippedSprite = true;
		} else if (Input.GetKey (KeyCode.D) && !Input.GetKey(KeyCode.A)) {
			flippedSprite = false;
		}

		meter.value += Time.deltaTime * 0.02f;
	}

	void spinToWin() {
		anim.SetTrigger("Attack");
	}

	public void ReduceEnergy () {
		meter.value -= 0.2f;
	}

	void EnableChild () {
		myCollider.enabled = false;
		child.enableHitbox();
		speed *= 3.3f;

	}


	void DisableChild () {
		myCollider.enabled = true;
		speed = tempSpeed;
		child.disableHitbox();
		anim.ResetTrigger("Attack");
	}

	void EnableCollider () {
		myCollider.enabled = true;
	}
	void DisableCollider () {
		myCollider.enabled = false;
	}

	void CanAttack () {
		canAttack = true;
	}
	void CantAttack () {
		canAttack = false;
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Obstacle") {
			Vector2 pushback = (transform.position - coll.gameObject.transform.position).normalized;
			rb.AddForce (pushback * (speed * 25));
			anim.SetTrigger("Bounce");
		} else if (coll.gameObject.tag == "Projectile") {
			Destroy (coll.gameObject);
			ReduceHearts ();
			anim.SetTrigger("Bounce");
		}
	}

	public void IncreaseHearts() {
		hp++;
		heartSource.Play ();
		switch (hp) {
		case 2:
			heart2.SetActive (true);
			break;
		case 3:
			heart3.SetActive (true);
			break;
		}
	}

	public void ReduceHearts() {
		hp--;
		ughSource.Play ();
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

	public void IncreaseEnergy(float value) {
		ahhSource.Play ();
		meter.value += value;
	}

	public int getHP() {
		return hp;
	}

	public float getEnergy() {
		return meter.value;
	}
}
