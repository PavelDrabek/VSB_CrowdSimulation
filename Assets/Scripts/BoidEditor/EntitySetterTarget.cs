using UnityEngine;
using System.Collections;

public class EntitySetterTarget : EntitySetter {

	public Transform targetTransform;
	public Vector3 targetPosition;

	#region implemented abstract members of EntitySetter
	public override void SetEntity (EntityController ec)
	{
		ec.entity.Target = targetTransform == null ? targetPosition : targetTransform.position;
	}
	#endregion
}
