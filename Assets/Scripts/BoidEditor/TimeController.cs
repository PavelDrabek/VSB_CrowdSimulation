using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	float time;
	float scale = 0;

	// Use this for initialization
	void Start () {
		time = Time.time;
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			Time.timeScale += 0.2f;
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			Time.timeScale -= 0.2f;
		}
		if(Input.GetKeyDown(KeyCode.Space)) {
			float tmp = Time.timeScale;
			Time.timeScale = scale;
			scale = tmp;
		}
	}

	void OnGUI() {
		GUI.color = Color.black;
		GUI.Label(new Rect(20, 40, 200, 20), "timescale: " + Time.timeScale + " time: " + (Time.time - time));
	}
}
