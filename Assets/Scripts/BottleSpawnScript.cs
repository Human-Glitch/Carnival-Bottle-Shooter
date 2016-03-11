using UnityEngine;
using System.Collections;


// Generates a random pyramid of objects and a platform for them before sending them along in a direction.
public class BottleSpawnScript : MonoBehaviour {

	// Array of Pyramid prefabs
	private GameObject[] targets;

	// Speed of platform & objects
	[SerializeField] private float speed = 500f;

	// The point in 3D space the platform & objects will appear
	[SerializeField] private float xOffset = 0f;
	[SerializeField] private float yOffset = 0f;
	[SerializeField] private float zOffset = 0f;

	// Time between automatic generation. make negitive to ignore.
	public float spawnTime = 2f;

	// Time until next object is created
	private float timeToSpawn = 0f;

	// Are we playing the game?
	public bool gameOn = false;

	// UI passed to platforms for scoring
	[SerializeField] private UIScript ui;

	//Initialization
	void Start () {

		// Load Target and Platform objects into targets array.
		// Note: Pyramids must be named "TargetN", where N is the number of the target from 1 to 5.
		targets = new GameObject[6];
		for (int x = 1; x < targets.Length; x++) {
			targets[x] = Resources.Load ("Target"+(x)) as GameObject;
		}
		targets [0] = Resources.Load ("Platform") as GameObject;

		//targets [1] = Resources.Load ("Target1Test") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

		// Countdown
		timeToSpawn -= Time.deltaTime;


		// If countdown hits zero and we are automatically spawning
		if (timeToSpawn <= 0 && spawnTime >= 0 && gameOn) {

			//reset countdown
			timeToSpawn = spawnTime;

			// Uncomment next line to only automatically spawn one object.
			//timeToSpawn = 9999999999999f;

			// Spawn object
			Spawn ();
		}
	}

	public void Spawn() {
		// Get random integer from 1 to 5, inclusive.
		int num = (int)(Random.value * 5 + 1);

		// Only if Random.value returns 1 exactly. Probably won't ever happen, so it doesn't mess up the distribution. But I don't want to break everything if it does.
		if (num == 6)
			num = 5;

		//num = 1;
		// Offset for each object from its center. Depends on the object. Probably shouldn't be hardcoded, but I don't want to put it anywhere else.
		// Turns out we don't actually need them. I'm a moron.
		/*
		float objX = 0f;
		float objY = 0f;
		float objZ = 0f;
		switch (num) {
			case 1:
				// Milk Bottles
				objX = -0.91f;
				objY = -1.52f;
				objZ = -17.73f;
				break;

			case 2:
				// Object 2
				objX = 0f;
				objY = 0f;
				objZ = 0f;
				break;

			case 3:
				// Object 3
				objX = 0f;
				objY = 0f;
				objZ = 0f;
				break;

			case 4:
				// Object 4
				objX = 0f;
				objY = 0f;
				objZ = 0f;
				break;

			case 5:
				// Object 5
				objX = 0f;
				objY = 0f;
				objZ = 0f;
				break;

			default:
				break;
		}*/

		// Create pyramid
		GameObject target = Instantiate(targets[num], new Vector3(xOffset, yOffset, zOffset), Quaternion.identity) as GameObject;
		//GameObject target = Instantiate(targets[1], new Vector3(-0.91f + xOffset, -1.52f + yOffset, -17.73f + zOffset), Quaternion.identity) as GameObject;

		// Create platform and tell it the speed & its pyramid
		GameObject platform = Instantiate (targets [0], new Vector3 (xOffset, yOffset, zOffset), Quaternion.identity) as GameObject;
		platform.GetComponent<PlatformScript> ().speed = speed;
		platform.GetComponent<PlatformScript> ().pyramid = target;
		platform.GetComponent<PlatformScript> ().ui = ui;
		platform.GetComponent<PlatformScript> ().spawner = this;

		TargetScript[] ts = target.GetComponentsInChildren<TargetScript> ();
		for (int x = 0; x < ts.Length; x++) {
			ts [x].platform = platform;
			ts [x].LockPlatformOffset();
		}

		// Setting the speed of every object in the pyramid to the initial speed. 
		// Otherwise the sudden jerk would be enough to knock the pyramid down.
		Rigidbody[] children = target.GetComponentsInChildren<Rigidbody> ();
		for (int x = 0; x < children.Length; x++) {
			children [x].velocity = new Vector3 (speed, 0f, 0f);
		}

		// A *Lot* of stuff that didn't work
		//target.GetComponent<Rigidbody> ().velocity = new Vector3 (speed, 0f, 0f);
		//target.GetComponent<PlatformScript>().speed = speed;
		/*Rigidbody rigidbody = target.GetComponent<Rigidbody> ();
		rigidbody.AddForce(new Vector3(speed, 0f, 0f));*/

	}

	public void StartGame() {
		gameOn = true;
	}

	public void StopGame() {
		gameOn = false;
	}
}
