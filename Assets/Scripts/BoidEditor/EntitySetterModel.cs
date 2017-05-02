using UnityEngine;
using System.Collections;

public class EntitySetterModel : EntitySetter {

	public GameObject prefabModel;

	public override void SetEntity(EntityController ec)
	{
		foreach(Transform t in ec.transform) {
			DestroyImmediate(t.gameObject);
		}
		GameObject model = Instantiate(prefabModel, ec.transform, false) as GameObject;
	}

}
