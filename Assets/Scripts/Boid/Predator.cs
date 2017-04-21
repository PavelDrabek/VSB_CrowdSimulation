using UnityEngine;
using System.Collections;

[System.Serializable]
public class Predator : Entity {

	public Predator(Boid boid, Vector3 position) : base(boid, position) {

	}

	override public Vector3 GetNextDirection() 
	{
		Vector3 dirToCenterSum = Vector3.zero;
		int count = 0;
		for (int i = 0; i < Boid.Entities.Count; i++) {
			if(Boid.Entities[i] == this) {
				continue;
			}

			Vector3 dirToEntity = Boid.Entities[i].Position - Position;
			if(Mathf.Acos(Vector3.Dot(dirToEntity, Boid.Entities[i].Direction)) * Mathf.Rad2Deg > Mathf.Max(ViewAngle, 179)) {
				continue;
			}

			dirToCenterSum += dirToEntity * (1 / dirToEntity.magnitude);
			count++;
		}

		Vector3 cohesion = count > 0 ? dirToCenterSum /= count : Vector3.zero;

//		return cohesion * Boid.CohesionCoef;
		return cohesion.normalized;
	}
}
