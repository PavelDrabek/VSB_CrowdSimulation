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
		}
	}
}
