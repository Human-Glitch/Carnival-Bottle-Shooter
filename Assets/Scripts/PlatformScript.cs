using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PlatformScript : MonoBehaviour {

	public float speed = 0f;
	private Rigidbody rb;
	[SerializeField] public GameObject pyramid;
	bool scored = false;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		// Responsible for the platform moving. 
		rb.velocity = new Vector3 (speed, 0f, 0f);

		// Scores once all bottles are destroyed
		if (!scored) {
			Rigidbody[] children = pyramid.GetComponentsInChildren<Rigidbody> ();
			if (children.Length == 0 && !scored) {
				// Score!
				print("Score!");
				scored = true;
			}
		}
	}
		
	// Destroys the pyramid and platform 
	public void Finished() {
		Destroy (pyramid);
		Destroy (this.gameObject);
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
}
