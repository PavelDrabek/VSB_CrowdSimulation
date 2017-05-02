using UnityEngine;
using System.Collections;

public class EntitySetterBehaviour : EntitySetter {

	[Range(1,179)]
	public float ViewAngle;
	public float ViewRange;
	public float CollisionRange;
	public float SpeedCoef;
	public float MaxSpeed;
	public float InertiaCoef;
	public float ObstacleLookahead;
	public float LookaheadCoef;

	[Range(0,1)]
	public float CohesionWeight;
	[Range(0,1)]
	public float AlignWeight;
	[Range(0,3)]
	public float SeparationWeight;
	[Range(0,3)]
	public float TargetWeight;

	public bool Fixed2D;
	public bool CanFinish;

	#region implemented abstract members of EntitySetter

	public override void SetEntity(EntityController ec)
	{
		ec.entity.ViewRange = ViewRange;
		ec.entity.ViewAngle = ViewAngle;
		ec.entity.CollisionRange = CollisionRange;
		ec.entity.MaxSpeed = MaxSpeed;
		ec.entity.SpeedCoef = SpeedCoef;
		ec.entity.InertiaCoef = InertiaCoef;
		ec.entity.CohesionWeight = CohesionWeight;
		ec.entity.AlignWeight = AlignWeight;
		ec.entity.SeparationWeight = SeparationWeight;
		ec.entity.TargetWeight = TargetWeight;
		ec.entity.CanFinish = CanFinish;
		ec.entity.ObstacleLookahead = ObstacleLookahead;
		ec.entity.LookaheadCoef = LookaheadCoef;
		ec.entity.fixed2D = Fixed2D;
	}

	#endregion

}
