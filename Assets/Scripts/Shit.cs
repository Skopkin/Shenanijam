using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shit : MonoBehaviour {

	public AudioSource poopSource;
	public AudioClip poopClip;
	// Use this for initialization
	void Start () {
		poopSource.clip = poopClip;
		poopSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
