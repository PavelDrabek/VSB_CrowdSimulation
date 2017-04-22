using UnityEngine;
using System.Collections;
using UnityEditor;

[ExecuteInEditMode]
public class GroupSetter : MonoBehaviour {

	public bool setEntities;
	public bool getEntities;
	public EntityController[] entities;

	void Update() {
		if (setEntities) {
			setEntities = false;
			CallSelectors ();
		}
		if (getEntities) {
			getEntities = false;
			GetEntities ();
		}
	}


	public void CallSelectors ()
	{
		EntitySetter[] setters = GetComponents<EntitySetter> ();
		for (int s = 0; s < setters.Length; s++) {
			setters [s].Prepare(entities.Length);
			for (int e = 0; e < entities.Length; e++) {
				setters [s].SetEntity(entities[e]);
			}
		}

		Debug.Log("Setting dirty");
		for (int e = 0; e < entities.Length; e++) {
			EditorUtility.SetDirty(entities[e].entity);
		}
	}

	public void GetEntities() {
		entities = GetComponentsInChildren<EntityController>();
	}
}
