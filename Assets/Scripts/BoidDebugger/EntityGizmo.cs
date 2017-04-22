using UnityEngine;
using System.Collections;

public class EntityGizmo : MonoBehaviour {

	private EntityController controller;
	private EntityController GetController() {
		if(controller == null) {
			controller = GetComponent<EntityController>();
		}
		return controller;
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.green;
		Gizmos.DrawLine(GetController().entity.Position, GetController().entity.Target);
	}
}
