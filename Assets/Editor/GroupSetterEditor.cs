using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GroupSetter))]
public class GroupSetterEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		GroupSetter setter = (GroupSetter)target;

		if(GUILayout.Button("Get entities"))
		{
			setter.GetEntities();
		}
		if(GUILayout.Button("Set entities"))
		{
			setter.CallSelectors();

			Debug.Log("Setting dirty");
			for (int e = 0; e < setter.entities.Length; e++) {
				EditorUtility.SetDirty(setter.entities[e].entity);
			}
		}
	}
}
