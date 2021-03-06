﻿using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(EntitySetter), true)]
public class EntitySetterEditor : Editor {

	private bool shouldUpdate = false;

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		shouldUpdate = GUILayout.Toggle(shouldUpdate, "test");

		if(shouldUpdate) {
			EntitySetter setter = (EntitySetter)target;
			GroupSetter groupSetter = setter.GetComponent<GroupSetter>();
			groupSetter.CallSetter(setter);
		}

		if(GUILayout.Button("Set entities"))
		{
			EntitySetter setter = (EntitySetter)target;
			GroupSetter groupSetter = setter.GetComponent<GroupSetter>();
			groupSetter.CallSetter(setter);

			Debug.Log("Setting dirty");
			for (int e = 0; e < groupSetter.entities.Length; e++) {
				EditorUtility.SetDirty(groupSetter.entities[e].entity);
			}
		}
	}
}
