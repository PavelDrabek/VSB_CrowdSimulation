using UnityEngine;
using System.Collections;

[System.Serializable]
public class Entity {

	public float ViewRange { get; set; }
	public float ViewAngle { get; set; }
	public float CollisionRange { get; set; }
	public float Speed { get; set; }
	public float Inertia { get; set;}
	public Vector3 Target { get; set; }

	public float CohesionCoef { get; set; }
	public float AlignCoef { get; set; }
	public float SeparationCoef { get; set; }
	public float PredatorSeparationCoef { get; set; }

	public Vector3 Position { get; set; }
	public Vector3 Direction { get; set; }
	public Boid Boid { get; private set; }

	public Entity(Boid boid, Vector3 position) 
	{
		Boid = boid;
		Position = position;
	}

	virtual public Vector3 GetNextDirection() 
	{
		Vector3 dirToCenterSum = Vector3.zero;
		Vector3 groupDirSum = Vector3.zero;
		Vector3 separation = Vector3.zero;
		Vector3 predatorDirSum = Vector3.zero;
		int count = 0;
		int predatorCount = 0;
		for (int i = 0; i < Boid.Entities.Count; i++) {
			if(Boid.Entities[i] == this) {
				continue;
			}

			Vector3 dirToEntity = Boid.Entities[i].Position - Position;
			if(Mathf.Acos(Vector3.Dot(dirToEntity, Boid.Entities[i].Direction)) * Mathf.Rad2Deg > Mathf.Max(ViewAngle, 179)) {
				continue;
			}

			if(Boid.Entities[i] is Predator) {
				predatorDirSum += dirToEntity;
			} else {
				float distance = dirToEntity.magnitude;
				if(distance < ViewRange) {
					count++;
					dirToCenterSum += dirToEntity;
					groupDirSum += Boid.Entities[i].Direction;
				}

				if(distance < CollisionRange) {
					separation += dirToEntity * (distance - CollisionRange);
				}
			}
		}

		Vector3 cohesion = count > 0 ? dirToCenterSum /= count : Vector3.zero;
		Vector3 align = count > 0 ? groupDirSum /= count : Vector3.zero;
		Vector3 predatorSeparation = predatorCount > 0 ? predatorDirSum / predatorCount : Vector3.zero;

		return cohesion * CohesionCoef 
			+ align * AlignCoef 
			+ separation * SeparationCoef 
			- predatorSeparation * PredatorSeparationCoef;
	}

}
