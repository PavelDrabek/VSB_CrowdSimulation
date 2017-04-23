using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntitySetterTarget : EntitySetter {

	public Transform targetCenter;
	public Vector3 size;
	public float spacing;
	public bool random;
	public Color color;

	#region implemented abstract members of EntitySetter

	private List<Vector3> positions = new List<Vector3>();

	public override void Prepare(int entityCount)
	{
		base.Prepare(entityCount);
		positions.Clear();
		Vector3 p = Vector3.zero;
		for (int i = 0; i < entityCount; i++) {
			positions.Add(p);
			p.x += spacing;
			if(p.x > size.x) {
				p.x = 0;
				p.z += spacing;
				if(p.z > size.z) {
					Debug.LogWarning("Not enought space");
				}
			}
		}
	}

	public override void SetEntity(EntityController ec)
	{
//		Vector3 rnd = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
//		rnd.Scale(size);
		int index = 0;
		if (random) {
			index = Random.Range(0, positions.Count - 1);
		}
		ec.entity.Target = targetCenter.position - size * 0.5f + positions[index];
		positions.RemoveAt(index);
	}

	#endregion

	void OnDrawGizmos() {
		if(targetCenter == null) {
			return;
		}

		Gizmos.color = color;
		Gizmos.DrawCube(targetCenter.position, size);
	}
}
