using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject credits;
	// Use this for initialization
	void Start () {
		MenuReturn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadLevel() {
		SceneManager.LoadScene ("Scene1");
	}

	public void Manual() {
		HideMenu ();
	}

	public void Credits() {
		HideMenu ();
		mainMenu.SetActive (false);
		credits.SetActive (true);
	}

	public void HideMenu() {
		
	}

	public void MenuReturn () {
		credits.SetActive (false);
		mainMenu.SetActive (true);
	}
}
