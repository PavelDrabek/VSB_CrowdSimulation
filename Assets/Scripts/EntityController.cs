using UnityEngine;
using System.Collections;

public class EntityController : MonoBehaviour {

	public Entity entity;
	public Transform myTransform;

	public MeshRenderer meshRenderer;

	void Update () {
		myTransform.position = entity.Position;
		myTransform.LookAt(entity.Position + entity.Direction, Vector3.up);
	}

	public void SetEntity(Entity e) {
		Debug.Log("setting entity");

		entity = e;
		if(e is Predator) {
			SetColor(Color.red);
		}
	}

	public void SetColor(Color c) {
		Material[] ms = meshRenderer.materials;
		for (int i = 0; i < ms.Length; i++) {
			ms[i].color = c;
		}
		meshRenderer.materials = ms;
	}
}
