using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Player player;
	public Text scoreText;
	public GameObject surfer1;
	private int score;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = "Dude Points: " + score;
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
		while(true) {
			for (int i = 0; i < hazardCount;i++) {
				bool b = (Random.value > 0.5f);
				float x;
				if (b) {
					x = player.maxX + 0.5f;
				} else {
					x = player.minX - 0.5f;
				}
				Vector2 spawnPosition = new Vector2 (x ,Random.Range (player.minY, player.maxY));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (surfer1, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void addScore(int value) {
		score += value;
		scoreText.text = "Dude Points: " + score;
	}
}
