using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject credits;
	public AudioSource waveSource;
	public AudioClip waveClip;
	// Use this for initialization
	void Start () {
		MenuReturn ();
		waveSource.clip = waveClip;
		waveSource.Play ();
		DontDestroyOnLoad (waveSource);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadLevel() {
		waveSource.volume = 0.15f;
		SceneManager.LoadScene ("Scene1");
	}

	public void Manual() {
		HideMenu ();
	}

	public void Credits() {
		HideMenu ();
		credits.SetActive (true);
	}

	public void HideMenu() {
		mainMenu.SetActive (false);
	}

	public void MenuReturn () {
		credits.SetActive (false);
		mainMenu.SetActive (true);
	}
}
