using UnityEngine;
using System.Collections;
using UnityEditor;

[ExecuteInEditMode]
public class GroupSetter : MonoBehaviour {

	public EntityController[] entities;

	public void CallSelectors ()
	{
		EntitySetter[] setters = GetComponents<EntitySetter> ();
		for (int s = 0; s < setters.Length; s++) {
			CallSetter(setters[s]);
		}

		Debug.Log("Setting dirty");
		for (int e = 0; e < entities.Length; e++) {
			EditorUtility.SetDirty(entities[e].entity);
		}
	}

	public void CallSetter(EntitySetter setter) {
		setter.Prepare(entities.Length);
		for (int e = 0; e < entities.Length; e++) {
			setter.SetEntity(entities[e]);
			EditorUtility.SetDirty(entities[e].entity);
		}
	}

	public void GetEntities() {
		entities = GetComponentsInChildren<EntityController>();
	}
}
