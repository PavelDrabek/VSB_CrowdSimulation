using UnityEngine;
using System.Collections;

public class EntityController : MonoBehaviour {

	[SerializeField]
	public Entity entity;
	public Transform myTransform;

	public MeshRenderer meshRenderer;

	void Update () {
		if(myTransform == null) {
			return;
		}

		myTransform.position = entity.Position;
		myTransform.LookAt(entity.Position + entity.Direction, Vector3.up);
	}

	public void SetEntity(Entity e) {
		entity = e;
		if(e is Predator) {
			Material[] ms = meshRenderer.materials;
			for (int i = 0; i < ms.Length; i++) {
				ms[i].color = Color.red;
			}
			meshRenderer.materials = ms;
		}
	}
}
