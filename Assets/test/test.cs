using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public GameObject prefab;
	public GameObject prefab2;
	public int step;
	public Color startColor;
	public Color stepColor;
	public Color endColor;

	public Vector3 v;
	public Vector3 axe;
	public float angle;

	public bool magic;

	// Use this for initialization
	void Start () {
//		Vector3 v = new Vector3(1,0,0);
//		Vector3 x = new Vector3(1,1,1);
//		float angle = 120;
	}

	void Update() {
		if(magic) {
			magic = false;
			DoMagic();
		}
	}

	void DoMagic() {
		Quaternion q = Quaternion.AngleAxis(angle, axe);
		Vector3 v_ = q * v;

		Debug.Log("v = " + v + ", v' = " + v_);

		Draw(v, Quaternion.identity, startColor);
		Draw(v_, q, endColor);

		for (int i = step; i < angle; i += step) {
			Quaternion q_ = Quaternion.AngleAxis(i, axe);
			Draw(q_ * v, q_, stepColor);
		}
	}

	void Draw(Vector3 pos, Quaternion rot, Color c) {
		GameObject g = Instantiate(prefab, pos, rot) as GameObject;
		MeshRenderer mr =  g.GetComponent<MeshRenderer>();
		Material m = mr.material;
		m.color = c;
		mr.material = m;
	}
}
