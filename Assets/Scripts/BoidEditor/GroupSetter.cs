using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GroupSetter : MonoBehaviour {

	public EntityController[] entities;

	public void CallSelectors ()
	{
		EntitySetter[] setters = GetComponents<EntitySetter> ();
		for (int s = 0; s < setters.Length; s++) {
			CallSetter(setters[s]);
		}
	}

	public void CallSetter(EntitySetter setter) {
		setter.Prepare(entities.Length);
		for (int e = 0; e < entities.Length; e++) {
			setter.SetEntity(entities[e]);
		}
	}

	public void GetEntities() {
		entities = GetComponentsInChildren<EntityController>();
	}
}
