using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		AudioSource sound = GetComponent<AudioSource> ();
		//if (sound != null && other.name != "BottomTarget1" && other.name != "BottomTarget2" && other.name != "TopTarget" && other.name != "Platform(Clone)") {
		if(sound != null && other.name == "tennis_ball(Clone)") {
			sound.Play ();
			print (other.name);
		}
	}
}
