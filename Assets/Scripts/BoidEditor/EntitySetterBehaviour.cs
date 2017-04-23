using UnityEngine;
using System.Collections;

public class EntitySetterBehaviour : EntitySetter {

	[Range(1,179)]
	public float ViewAngle;
	public float ViewRange;
	public float CollisionRange;
	public float MaxSpeed;
	public float InertiaCoef;

	[Range(0,1)]
	public float CohesionWeight;
	[Range(0,1)]
	public float AlignWeight;
	[Range(0,3)]
	public float SeparationWeight;
	[Range(0,3)]
	public float TargetWeight;

	public bool CanFinish;

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
		ec.entity.CanFinish = CanFinish;
	}

	#endregion

}
