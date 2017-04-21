using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GroupSelector : MonoBehaviour {

	public EntityController[] entities;
	public bool setEntities;

	void Update() {
		if (setEntities) {
			setEntities = false;
			CallSelectors ();
		}
	}


	void CallSelectors ()
	{
		EntitySetter[] setters = GetComponents<EntitySetter> ();
		for (int s = 0; s < setters.Length; s++) {
			for (int e = 0; e < entities.Length; e++) {
				setters [s].SetEntity(entities[e]);
			}
		}
	}
}
