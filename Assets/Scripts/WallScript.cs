using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other) {
		if (other.name == "Platform(Clone)") {
			other.gameObject.GetComponent<PlatformScript> ().Finished();
		}
	}
}
