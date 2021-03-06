﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntitySetterPosition : EntitySetter {

	public Transform center;
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
				p.y += spacing;
				if(p.y > size.y) {
					p.y = 0;
					p.z += spacing;
					if (p.z > size.z) {

					}
				}
			}
		}
	}

	public override void SetEntity(EntityController ec)
	{
		int index = 0;
		if (random) {
			index = Random.Range(0, positions.Count - 1);
		}
		ec.entity.Position = center.position - size * 0.5f + positions[index];
		ec.myTransform.position = ec.entity.Position;
		positions.RemoveAt(index);
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
