using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Player player;
	public GameObject surfer1;
	public GameObject heart;
	public GameObject coffee;
	public GameObject seagull;
	public AudioSource bgmSource;
	public AudioClip bgmClip;
	public Text pausedText;
	private int score;
	private int waveCount;
	public Text scoreText;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = "Dude Points: " + score; 
		pausedText.enabled = false;
		bgmSource.clip = bgmClip;
		bgmSource.Play ();
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
		if (player.getHP() == 0)
			GameOver ();

		if (Input.GetKeyDown (KeyCode.Escape))
			Pause ();
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
		waveCount = 0;
		while(true) {
			waveCount += 1;
			for (int i = 0; i < hazardCount;i++) {
				spawnEnemy (surfer1);

				if (i > 0 && i % 3 == 0)
					spawnEnemy (seagull);
				
				if (Random.Range (1, 10) == 2 && i >= hazardCount / 2)
					spawnPickup (coffee);
				yield return new WaitForSeconds (spawnWait);
			}
			if (waveCount != 0 && waveCount % 3 == 0 && spawnWait > 1)
				spawnWait -= 0.5f;
			hazardCount += 4;
			spawnPickup (heart);
			yield return new WaitForSeconds (waveWait);
		}
	}

	void Pause() {
		if (Time.timeScale == 1) {
			bgmSource.Pause ();
			Time.timeScale = 0;
			pausedText.enabled = true;
		} else {
			bgmSource.UnPause ();
			Time.timeScale = 1;
			pausedText.enabled = false;
		}
	}

	void GameOver() {
		Time.timeScale = 0.5f;
		Animator myAnimator = player.GetComponent<Animator> ();
		myAnimator.SetBool ("Fall", true);
		Invoke ("LoadMenu", 2f);

	}

	public void addScore(int value) {
		score += value;
		scoreText.text = "Dude Points: " + score; 
	}

	private void spawnPickup(GameObject o) {
		Vector2 pickupSpawnPosition = new Vector2 (Random.Range (player.minX, player.maxX), -5.3f);
		Quaternion pickupSpawnRotation = Quaternion.identity;
		Instantiate (o, pickupSpawnPosition, pickupSpawnRotation);
	}

	private void spawnEnemy (GameObject o) {
		bool b = (Random.value > 0.5f);
		float x, y;
		if (b) {
			x = player.maxX + 2f;
		} else {
			x = player.minX - 2f;
		}

		if (o == seagull)
			y = 4.45f;
		else
			y = Random.Range (player.minY, player.maxY);
		
		Vector2 spawnPosition = new Vector2 (x, y);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (o, spawnPosition, spawnRotation);
	}

	void LoadMenu() {
		SceneManager.LoadScene ("Menu");
	}
}
