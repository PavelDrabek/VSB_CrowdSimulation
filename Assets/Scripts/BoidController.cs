using UnityEngine;
using System.Collections;

public class BoidController : MonoBehaviour {

//	public float timeScale;

	public Boid boid;

	void Update () {
		boid.UpdateBoid(Time.deltaTime);
	}
}
