using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EntityEventArgs : EventArgs {
	public Entity entity;
}

public class Boid {

//	public float CohesionCoef { get; set; }
//	public float AlignCoef { get; set; }
//	public float SeparationCoef { get; set; }
//	public float PredatorSeparationCoef { get; set; }
//	public float Inertia { get; set; }
//
//	public float EntityCollisionRange { get; set; }
//	public float EntityViewRange { get; set; }
//	public float EntityViewAngle { get; set; }
//	public float EntitySpeed{ get; set; }
	
//	public Vector3 Target { get; set; }

	public List<Entity> Entities { get; private set; }

	public event EventHandler<EntityEventArgs> OnEntityAdd;
	public event EventHandler<EntityEventArgs> OnEntityRemove;

	public Boid() {
		Entities = new List<Entity>();
	}

	public void Update(float deltaTime) 
	{
		Vector3[] nextDirections = new Vector3[Entities.Count];
		for (int i = 0; i < Entities.Count; i++) {
			nextDirections[i] = Entities[i].GetNextDirection();
		}

		for (int i = 0; i < Entities.Count; i++) {
			Entities[i].Direction = Vector3.Lerp(Entities[i].Direction, nextDirections[i].normalized, Entities[i].Inertia).normalized;
//			Entities[i].Direction = nextDirections[i].normalized;
			Entities[i].Position += Vector3.ClampMagnitude(Entities[i].Direction, Entities[i].Speed * deltaTime);
		}
	}

	public void AddEntity(Entity entity) {
		Entities.Add(entity);

		if(OnEntityAdd != null) {
			OnEntityAdd(this, new EntityEventArgs { entity = entity });
		}
	}

	public void RemoveEntity(Entity entity) {
		if(OnEntityRemove != null) {
			OnEntityRemove(this, new EntityEventArgs { entity = entity });
		}
		Entities.Remove(entity);
	}

	public void RemoveEntity(int index) {
		RemoveEntity(Entities[index]);
	}

}
