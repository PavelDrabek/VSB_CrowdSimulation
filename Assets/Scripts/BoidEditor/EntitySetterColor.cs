using UnityEngine;
using System.Collections;

public class EntitySetterColor : EntitySetter {

	public Color color;

	#region implemented abstract members of EntitySetter

	public override void SetEntity (EntityController ec)
	{
		MeshRenderer mr = ec.GetComponentInChildren<MeshRenderer>();
		if (mr != null) {
			mr.material.color = color;
		} else {
			SkinnedMeshRenderer smr = ec.GetComponentInChildren<SkinnedMeshRenderer>();
			if (smr != null) {
				smr.material.color = color;
			}
		}
	}

	#endregion

}
