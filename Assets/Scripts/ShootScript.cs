using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

	public float WAIT_TIME = 1f;
	float time = 0;

	public Rigidbody projectile;
	public Transform shotPos;	//eventually will hold end of barrel location
	public float shotForce = 1000f;

	private bool gameOn = false;

	void Start() {
	}

	void Update () {
		time += Time.deltaTime;
		
		//the second argument in the Instantiate() function should be barrel of gun when finished
		//May want to eventually set a time limit between refire
		if(Input.GetMouseButtonDown(0) && gameOn){
			if (time >= WAIT_TIME) {
				Rigidbody ball = Instantiate (projectile, shotPos.position, shotPos.rotation) as Rigidbody;
				ball.AddForce (shotPos.forward * shotForce);
				GetComponent<AudioSource> ().Play ();

				//After 5 seconds, the ball clone is deleted
				//Destroy (ball.gameObject, 5);

				time = 0;
			}

		}

	}


	public void StartGame()
	{
		gameOn = true;
	}

	public void StopGame() {
		gameOn = false;
	}

}
