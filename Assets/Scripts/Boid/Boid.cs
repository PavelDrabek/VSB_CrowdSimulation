using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EntityEventArgs : EventArgs {
	public Entity entity;
}

public class Boid : MonoBehaviour {
	
	public List<Entity> Entities = new List<Entity>();

	public event EventHandler<EntityEventArgs> OnEntityAdd;
	public event EventHandler<EntityEventArgs> OnEntityRemove;

	public void UpdateBoid(float deltaTime) 
	{
		for (int i = 0; i < Entities.Count; i++) {
			Entities[i].CalculateMovement();
		}

		for (int i = 0; i < Entities.Count; i++) {
			Entities[i].ApplyMovement(deltaTime);
		}
	}

	public void AddEntity(Entity entity) {
		Debug.Log("Adding entity");
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
