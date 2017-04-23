using UnityEngine;
using System.Collections;

public class EntityGizmo : MonoBehaviour {

	private EntityController controller;
	private EntityController Controller { get {
			if (controller == null) {
				controller = GetComponent<EntityController>();
			}
			return controller;
		}
	}

	void OnDrawGizmosSelected() {
		Entity e = Controller.entity;
		Gizmos.color = Color.green;
		Gizmos.DrawLine(e.Position, e.Target);
		Gizmos.DrawWireSphere(e.Position, e.ViewRange);
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(e.Target, 0.1f);
		Gizmos.DrawWireSphere(e.Position, e.CollisionRange);
		Gizmos.DrawLine(e.Position, e.Position + e.separation * e.SeparationWeight);
		Gizmos.color = Color.cyan;
		Gizmos.DrawLine(e.Position, e.Position + e.align * e.AlignWeight);
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(e.Position, e.Position + e.cohesion * e.CohesionWeight);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(e.Position, e.Position + e.Direction);
	}
}
