using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class BottleSpawnScript : MonoBehaviour {

	private GameObject[] targets;
	private Stopwatch stopwatch;
	[SerializeField] private float speed = 500f;

	// Use this for initialization
	void Start () {
		targets = new GameObject[5];

		for (int x = 0; x < targets.Length; x++) {
			targets[x] = Resources.Load ("Target"+(x+1)) as GameObject;
		}

		targets [0] = Resources.Load ("Target1Test") as GameObject;
		stopwatch = Stopwatch.StartNew();
	}
	
	// Update is called once per frame
	void Update () {
		if (stopwatch.ElapsedMilliseconds > 20) {
			Spawn ();
			stopwatch.Reset ();
			//stopwatch = Stopwatch.StartNew ();
		}
	}

	public void Spawn() {
		int num = (int)(Random.value * 5 + 1);
		print(num);
		GameObject target = Instantiate(targets[0], new Vector3(-5, 0, 0), Quaternion.identity) as GameObject;
		//target.GetComponent<Rigidbody> ().velocity = new Vector3 (speed, 0f, 0f);
		Rigidbody[] rb = target.GetComponentsInChildren<Rigidbody> ();
		for (int x = 0; x < rb.Length; x++) {
			rb [x].velocity = new Vector3 (speed, 0f, 0f);
		}
		/*Rigidbody rigidbody = target.GetComponent<Rigidbody> ();
		rigidbody.AddForce(new Vector3(speed, 0f, 0f));*/

	}
}
