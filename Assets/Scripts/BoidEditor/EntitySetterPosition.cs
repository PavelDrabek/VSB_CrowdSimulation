using UnityEngine;
using System.Collections;

public class EntitySetterPosition : EntitySetter {

	struct PositionParams {
		public int count;
		public float step;
		public float size;
	}

	public Transform from;
	public Transform to;

	private PositionParams X, Z;

	#region implemented abstract members of EntitySetter

	public override void Prepare(int entityCount)
	{
		base.Prepare(entityCount);
		X.size = to.position.x - from.position.x;
		Z.size = to.position.z - from.position.z;
	}

	public override void SetEntity(EntityController ec)
	{
		ec.entity.Position = from.position + new Vector3(Random.Range(0, X.size), 0, Random.Range(0, Z.size));
		ec.myTransform.position = ec.entity.Position;
	}

	#endregion

	void OnDrawGizmos() {
		if(to == null || from == null) {
			return;
		}

		float w = to.position.x - from.position.x;
		float h = to.position.z - from.position.z;
		Vector3 size = new Vector3(w, 0.1f, h);
		Vector3 center = to.position - size * 0.5f;

		Gizmos.color = Color.yellow;
		Gizmos.DrawCube(center, size);
	}

}
