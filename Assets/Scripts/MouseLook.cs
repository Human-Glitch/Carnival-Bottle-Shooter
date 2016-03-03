using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	public enum RotationAxes{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	public float minimumHoriz = -45.0f;
	public float maximumHoriz = 45.0f;

	private float _rotationX = 0;
	private float _rotationY = 0;

	// Use this for initialization
	void Start () {
		Rigidbody body = GetComponent<Rigidbody> ();
		if (body != null)
			body.freezeRotation = true;

		//Cursor.visible = !Cursor.visible;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Hides the cursor when playing the game
		if (Input.GetKeyDown ("space"))
			Cursor.visible = !Cursor.visible;

		//Gets Camera input and clamps the angle of the input
		if (axes == RotationAxes.MouseX) {
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityHor, 0);
		} 
		else if (axes == RotationAxes.MouseY) {
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

		} 
		else {
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

			_rotationY -= Input.GetAxis ("Mouse X") * sensitivityHor;
			_rotationY = Mathf.Clamp (_rotationY, minimumHoriz, maximumHoriz);

			transform.localEulerAngles = new Vector3 (_rotationX, -(_rotationY), 0);
		}
	
	}
}
