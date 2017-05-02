using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speed;
	public float rotationSpeed;

	public Transform rotateAround;
	public float distance;

	public float x, y;

	// Use this for initialization
	void Start () {
		//x = y = 0;
	}
	
	// Update is called once per frame
	void Update () {
		y -= Input.GetAxis("Horizontal");
		x += Input.GetAxis("Vertical");

		if(Input.GetKey(KeyCode.Q)) {
			distance += 1;
		}
		if(Input.GetKey(KeyCode.E)) {
			distance -= 1;
		}


		Vector3 dir = Quaternion.AngleAxis(y, Vector3.up) * Quaternion.AngleAxis(x, Vector3.right) * Vector3.forward;
		transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
		transform.position = rotateAround.position + transform.forward * -distance;
	}
}
