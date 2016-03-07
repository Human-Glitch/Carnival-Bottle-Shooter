using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.name == "BottomTarget1" || other.name == "BottomTarget2" || other.name == "TopTarget") {
			Destroy (other.gameObject);
		}
	}
}
