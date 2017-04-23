using UnityEngine;
using System.Collections;

public class EntitySetterBehaviour : EntitySetter {

	public float ViewRange;
	public float ViewAngle;
	public float CollisionRange;
	public float MaxSpeed;
	public float InertiaCoef;

	public float CohesionWeight;
	public float AlignWeight;
	public float SeparationWeight;
	public float TargetWeight;


	#region implemented abstract members of EntitySetter

	public override void SetEntity(EntityController ec)
	{
		ec.entity.ViewRange = ViewRange;
		ec.entity.ViewAngle = ViewAngle;
		ec.entity.CollisionRange = CollisionRange;
		ec.entity.MaxSpeed = MaxSpeed;
		ec.entity.InertiaCoef = InertiaCoef;
		ec.entity.CohesionWeight = CohesionWeight;
		ec.entity.AlignWeight = AlignWeight;
		ec.entity.SeparationWeight = SeparationWeight;
		ec.entity.TargetWeight = TargetWeight;
	}

	#endregion

}
