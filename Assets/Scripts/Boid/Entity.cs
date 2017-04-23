﻿using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public float ViewRange;
	public float ViewAngle;
	public float CollisionRange;
	public float MaxSpeed;
	public float InertiaCoef;

	public float CohesionWeight;
	public float AlignWeight;
	public float SeparationWeight;
	public float TargetWeight;

	public Vector3 Target;

	public Vector3 Position;
	public Vector3 Direction;
	public Boid Boid;

	public bool isFinished;
	protected Vector3 nextVelocity;

	public Vector3 cohesion { get; protected set; }
	public Vector3 align{ get; protected set; }
	public Vector3 separation { get; protected set; }
	public Vector3 dirToTarget { get; protected set; }

	public virtual void Init(Boid boid, Vector3 position) 
	{
		Boid = boid;
		Position = position;
		isFinished = false;
	}

	virtual public void CalculateMovement()
	{
		if (isFinished) {
			isFinished = true;
			return;
		}

		cohesion = Vector3.zero;
		align = Vector3.zero;
		separation = Vector3.zero;
		dirToTarget = (Target - Position).normalized;

		int count = 0;
		for (int i = 0; i < Boid.Entities.Count; i++) {
			if (Boid.Entities[i] == this) {
				continue;
			}

			Vector3 velToEntity = Boid.Entities[i].Position - Position;
			if (Mathf.Acos(Vector3.Dot(velToEntity, Direction)) * Mathf.Rad2Deg > Mathf.Min(ViewAngle, 179)) {
				continue;
			}

			float distance = velToEntity.magnitude;
			if (distance < ViewRange && !Boid.Entities[i].isFinished) {
				count++;
				cohesion += velToEntity;
				align += Boid.Entities[i].Direction;
			}

			if (distance < CollisionRange) {
				separation -= velToEntity.normalized * (CollisionRange / velToEntity.magnitude);
			}
		}

		if (count > 0) {
			cohesion /= count;
			align /= count;
		}

		nextVelocity = cohesion * CohesionWeight
			+ align * AlignWeight
			+ separation * SeparationWeight
			+ dirToTarget * TargetWeight;
	}

	virtual public void ApplyMovement(float deltaTime) {
		if(isFinished) {
			return;
		}

		Quaternion rot = Quaternion.LookRotation(Direction, Vector3.up);
		Quaternion rotNext = Quaternion.LookRotation(nextVelocity, Vector3.up);

		if(rot != rotNext) {
			Direction = Quaternion.Slerp(rot, rotNext, InertiaCoef * deltaTime) * Vector3.forward;
			//Direction = Vector3.Lerp(Direction, nextVelocity, Inertia);
		} else {
			Direction = nextVelocity;
		}

		Position += Vector3.ClampMagnitude(Direction, MaxSpeed) * deltaTime;

		if(Vector3.Distance(Position, Target) < 0.1f) {
			isFinished = true;
		}
	}

}
