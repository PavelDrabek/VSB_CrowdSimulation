using UnityEngine;
using System.Collections;

public class EntitySetterPosition : EntitySetter {

	public Transform center;
	public Vector3 size;
	public Color color;

	#region implemented abstract members of EntitySetter

	public override void SetEntity(EntityController ec)
	{
		Vector3 rnd = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
		rnd.Scale(size);
		ec.entity.Position = center.position + rnd;
		ec.myTransform.position = ec.entity.Position;
	}

	#endregion

	void OnDrawGizmos() {
		if(center == null) {
			return;
		}
			
		Gizmos.color = color;
		Gizmos.DrawCube(center.position, size);
	}

}
