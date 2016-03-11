using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PlatformScript : MonoBehaviour {

	public float speed = 0f;
	private Rigidbody rb;
	[SerializeField] public GameObject pyramid;
	bool scored = false;
	private int finishedFlag = 0;
	private float timeToDestruction = 5f;
	public UIScript ui;
	public BottleSpawnScript spawner;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		// Responsible for the platform moving. 
		rb.velocity = new Vector3 (speed, 0f, 0f);

		if (!spawner.gameOn) {
			Destroy (pyramid);
			Destroy (this.gameObject);
		}
		// Scores once all bottles are destroyed
		else if (!scored) {
			TargetScript[] children = pyramid.GetComponentsInChildren<TargetScript> ();
			/*if (children.Length == 0 && !scored) {
				// Score!
				print("Score!");
				scored = true;
			}*/

			if(AreOff(children)) {
				ui.playerScored ();
				//print("Score!");
				scored = true;
			}
		}

		timeToDestruction -= Time.fixedDeltaTime * finishedFlag;

		if (timeToDestruction <= 0) {
			Destroy (pyramid);
			Destroy (this.gameObject);
		}
	}
		
	// Destroys the pyramid and platform 
	public void Finished() {
		finishedFlag = 1;
		// Destroy (pyramid);
		// Destroy (this.gameObject);
	}

	/*
	Bounds GetMaxBounds(GameObject g) {
		//code from http://gamedev.stackexchange.com/questions/86863/calculating-the-bounding-box-of-a-game-object-based-on-its-children
		var b = new Bounds (g.transform.position, Vector2.zero);
		foreach (Renderer r in g.GetComponentsInChildren<Renderer>()) {
			b.Encapsulate (r.bounds);
		}
		return b;
	}*/

	public bool AreOff(TargetScript[] obj) {
		for (int x = 0; x < obj.Length; x++) {
			if (obj[x].CloseToHome()) {
				return false;
			}
		}
		return true;
	}
}
