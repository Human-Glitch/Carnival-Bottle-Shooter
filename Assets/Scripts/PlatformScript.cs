using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	public float speed = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.y += speed * Time.deltaTime;
		transform.position = pos;
	}
}
