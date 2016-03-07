using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PlatformScript : MonoBehaviour {

	public float speed = 0f;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame	
	void FixedUpdate () {
		rb.velocity = new Vector3 (speed, 0f, 0f);
	}
}
