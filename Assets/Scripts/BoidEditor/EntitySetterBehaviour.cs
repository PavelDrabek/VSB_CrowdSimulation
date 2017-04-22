using UnityEngine;
using System.Collections;

public class EntitySetterBehaviour : EntitySetter {

	public float ViewRange;
	public float ViewAngle;
	public float CollisionRange;
	public float Speed;
	public float Inertia;

	public float CohesionCoef;
	public float AlignCoef;
	public float SeparationCoef;
	public float PredatorSeparationCoef;


	#region implemented abstract members of EntitySetter

	public override void SetEntity(EntityController ec)
	{
		ec.entity.ViewRange = ViewRange;
		ec.entity.ViewAngle = ViewAngle;
		ec.entity.CollisionRange = CollisionRange;
		ec.entity.Speed = Speed;
		ec.entity.Inertia = Inertia;
		ec.entity.CohesionCoef = CohesionCoef;
		ec.entity.AlignCoef = AlignCoef;
		ec.entity.SeparationCoef = SeparationCoef;
		ec.entity.PredatorSeparationCoef = PredatorSeparationCoef;
	}

	#endregion

}
