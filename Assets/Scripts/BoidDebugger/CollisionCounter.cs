using UnityEngine;
using System.Collections;

public class CollisionCounter : MonoBehaviour {

	public static int collisions;
	private static float timeSinceStart;

	// Use this for initialization
	void Start () {
		collisions = 0;
		timeSinceStart = Time.realtimeSinceStartup;
	}
	
	void OnTriggerEnter(Collider c) {
		collisions++;
	}

	void OnGUI() {
		GUI.color = Color.black;
		GUI.Label(new Rect(20, 20, 200, 20), "collisions/s: " + (int)(collisions / (Time.realtimeSinceStartup - timeSinceStart)) + ", count: " + collisions);
	}
}
