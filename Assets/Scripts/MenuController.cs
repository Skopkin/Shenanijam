using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject credits;
	public GameObject controls;
	public AudioSource waveSource;
	public AudioClip waveClip;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
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
		controls.SetActive (true);
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
		controls.SetActive (false);
	}
}
