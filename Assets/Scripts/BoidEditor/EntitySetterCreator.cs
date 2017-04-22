using UnityEngine;
using System.Collections;

public class EntitySetterCreator : EntitySetter {

	private BoidController boidController;
	private BoidController GetBoidController() {
		if(boidController == null) {
			boidController = FindObjectOfType<BoidController>();
		}
		return boidController;
	}

	#region implemented abstract members of EntitySetter

	public override void SetEntity(EntityController ec)
	{
		Debug.Log("Setting entity");
		Boid b = GetBoidController().boid;
		ec.entity.Init(b, Vector3.zero);
		if(!b.Entities.Contains(ec.entity)) {
			b.AddEntity(ec.entity);
		}
	}

	#endregion



}
