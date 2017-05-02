using UnityEngine;
using System.Collections;

public class EntitySetterModel : EntitySetter {

	public GameObject prefabModel;
	public bool onlyDeleteModel;

	public override void SetEntity(EntityController ec)
	{
		foreach(Transform t in ec.transform) {
			DestroyImmediate(t.gameObject);
		}
		if (!onlyDeleteModel) {
			GameObject model = Instantiate(prefabModel, ec.transform, false) as GameObject;
		}
	}

}
