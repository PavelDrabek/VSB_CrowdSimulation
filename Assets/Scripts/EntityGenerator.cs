using UnityEngine;
using System.Collections;

public class EntityGenerator : MonoBehaviour {

	public EntityController prefabEntity;
	private BoidController boidController;

	public int count = 30;
	public float range = 10;
	public bool generate = false;
	public bool clear = false;

	void Start() {
		boidController = GameObject.FindObjectOfType<BoidController>();
	}

	void Update () {

		if(generate) {
			generate = false;
			Generate(Vector3.zero);
		}

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
			GenerateEntity(randomPos);
		}
	}

	public void GenerateEntity(Vector3 position) {
//		Entity e = new Entity(boidController.Boid, position);
//		if(type == EntityType.Predator) {
//			e = new Predator(boidController.Boid, position);
//		} else {
//			e = new Entity(boidController.Boid, position);
//		}
		EntityController eController = Instantiate(prefabEntity, boidController.transform) as EntityController;
		eController.entity.Init(boidController.boid, position);
//		eController.SetEntity(e);
		boidController.boid.AddEntity(eController.entity);
	}
}
