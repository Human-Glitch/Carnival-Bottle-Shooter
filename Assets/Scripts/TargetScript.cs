using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

	[HideInInspector] public GameObject platform;
	private float xOff = 0f;
	private float yOff = 0f;

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
		}
	}

	public void LockPlatformOffset() {
		xOff = transform.position.x - platform.transform.position.x;
		yOff = transform.position.y - platform.transform.position.y;
	}

	public bool CloseToHome() {
		float currentXOff = transform.position.x - platform.transform.position.x - xOff;
		float currentYOff = transform.position.y - platform.transform.position.y - yOff;

		if (Mathf.Sqrt (currentXOff * currentXOff + currentYOff * currentYOff) > 3)
			return false;
		else
			return true;

	}
}
