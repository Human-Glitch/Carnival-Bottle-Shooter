using UnityEngine;
using System.Collections;

public class MovingLight : MonoBehaviour {

	public float speed = 9f;

	private float _rotationX = 9f;
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0, _rotationX, 0);

		_rotationX = Mathf.Clamp(_rotationX, -.5f, .5f);
	
	}
}
