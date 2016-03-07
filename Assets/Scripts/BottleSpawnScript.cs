using UnityEngine;
using System.Collections;

public class BottleSpawnScript : MonoBehaviour {

	private GameObject[] targets;
	[SerializeField] private float speed = 500f;
	[SerializeField] private float xOffset = 0f;
	[SerializeField] private float yOffset = 0f;
	[SerializeField] private float zOffset = 0f;
	public float spawnTime = 2f;
	private float timeToSpawn = 0f;

	// Use this for initialization
	void Start () {

		targets = new GameObject[6];

		for (int x = 1; x < targets.Length; x++) {
			targets[x] = Resources.Load ("Target"+(x+1)) as GameObject;
		}

		targets [0] = Resources.Load ("Platform") as GameObject;

		targets [1] = Resources.Load ("Target1Test") as GameObject;


	}
	
	// Update is called once per frame
	void Update () {
		timeToSpawn -= Time.deltaTime;

		if (timeToSpawn <= 0) {
			timeToSpawn = spawnTime;
			//timeToSpawn = 9999999999999f;
			Spawn ();
		}
	}

	public void Spawn() {
		int num = (int)(Random.value * 5 + 1);
		if (num == 6)
			num = 5;
		
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
		}


		//GameObject target = Instantiate(targets[num], new Vector3(objX + xOffset, objY + yOffset, objZ + zOffset), Quaternion.identity) as GameObject;
		GameObject target = Instantiate(targets[1], new Vector3(-0.91f + xOffset, -1.52f + yOffset, -17.73f + zOffset), Quaternion.identity) as GameObject;
		GameObject platform = Instantiate (targets [0], new Vector3 (xOffset, yOffset, zOffset), Quaternion.identity) as GameObject;
		platform.GetComponent<PlatformScript> ().speed = speed;

		Rigidbody[] children = target.GetComponentsInChildren<Rigidbody> ();

		for (int x = 0; x < children.Length; x++) {
			children [x].velocity = new Vector3 (speed, 0f, 0f);
		}

		//target.GetComponent<Rigidbody> ().velocity = new Vector3 (speed, 0f, 0f);
		//target.GetComponent<PlatformScript>().speed = speed;
		/*Rigidbody rigidbody = target.GetComponent<Rigidbody> ();
		rigidbody.AddForce(new Vector3(speed, 0f, 0f));*/

	}
}
