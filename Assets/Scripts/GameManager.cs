using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Player player;
	public Text scoreText;
	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = "Dude Points: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addScore(int value) {
		score += value;
		scoreText.text = "Dude Points: " + score;
	}
}
