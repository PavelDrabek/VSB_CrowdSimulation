using UnityEngine;
using System.Collections;

public class EntityGenerator : MonoBehaviour {

	private Boid boid;

	public EntityType type;
	public int count;
	public float range;

	void Start() {
		boid = GameObject.FindObjectOfType<BoidController>().boid;
	}

	void Update () {
		if ( Input.GetMouseButtonDown (0)){ 
			RaycastHit hit; 
			int layer = 1 << 8;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if ( Physics.Raycast (ray, out hit, 100000.0f, layer)) {
//				Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
				Generate(hit.point);
			}
		}
	}

	public void Generate(Vector3 position) {
		position.y = 0;

		for (int i = 0; i < count; i++) {
			Vector3 randomPos = Vector3.Scale(Random.insideUnitSphere * range, new Vector3(1, 0, 1));
			Entity e = null;
			if(type == EntityType.Predator) {
				e = new Predator(boid, randomPos);
			} else {
				e = new Entity(boid, randomPos);
			}
			boid.AddEntity(e);
		}
	}

}
