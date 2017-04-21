using UnityEngine;
using System.Collections;

public class EntitySetterColor : EntitySetter {

	public Color color;

	#region implemented abstract members of EntitySetter

	public override void SetEntity (EntityController ec)
	{
		ec.meshRenderer.sharedMaterial.color = color;
	}

	#endregion

}
