using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public float ViewRange;
	public float ViewAngle;
	public float CollisionRange;
	public float MaxSpeed;
	public float Inertia;

	public float CohesionCoef;
	public float AlignCoef;
	public float SeparationCoef;
	public float TargetCoef;
	public float PredatorSeparationCoef;

	public Vector3 Target;

	public Vector3 Position;
	public Vector3 Direction;
	public Boid Boid;

	public bool isFinished;
	protected Vector3 nextDirection;

	public virtual void Init(Boid boid, Vector3 position) 
	{
		Boid = boid;
		Position = position;
	}

	virtual public void CalculateMovement() 
	{
		if(isFinished) {
			isFinished = true;
			return;
		}

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

		separation.Normalize();
		Vector3 cohesion = Vector3.ClampMagnitude(count > 0 ? dirToCenterSum /= count : Vector3.zero, 1);
		Vector3 align = Vector3.ClampMagnitude(count > 0 ? groupDirSum /= count : Vector3.zero, 1);
		Vector3 predatorSeparation = Vector3.ClampMagnitude(predatorCount > 0 ? predatorDirSum / predatorCount : Vector3.zero, 1);
		Vector3 dirToTarget = (Target - Position).normalized;


		nextDirection = cohesion * CohesionCoef 
			+ align * AlignCoef 
			+ separation * SeparationCoef 
			+ dirToTarget * TargetCoef
			- predatorSeparation * PredatorSeparationCoef;
	}

	virtual public void ApplyMovement(float deltaTime) {
		if(isFinished) {
			return;
		}

		Direction = Vector3.Lerp(Direction, nextDirection, Inertia).normalized;
		Position += Vector3.ClampMagnitude(Direction, MaxSpeed * deltaTime);

		if(Vector3.Distance(Position, Target) < 0.1f) {
			isFinished = true;
		}
	}

}
