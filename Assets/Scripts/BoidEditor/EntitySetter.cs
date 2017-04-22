using UnityEngine;
using System.Collections;

public abstract class EntitySetter : MonoBehaviour {
	public virtual void Prepare(int entityCount) {}
	public abstract void SetEntity (EntityController ec);
}
