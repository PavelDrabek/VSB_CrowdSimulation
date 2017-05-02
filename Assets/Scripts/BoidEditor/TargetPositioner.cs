using UnityEngine;
using System.Collections;

public class TargetPositioner : MonoBehaviour {

	public GroupSetter groupSetter;
	public Transform target;
	public Vector3 area;
	public float delay;

	private float lastRespawn;

	void Update() 
	{
		if(Time.time > lastRespawn + delay) {
			Respawn();
		}
	}

	void Respawn() 
	{
		lastRespawn = Time.time;
		Vector3 newTarget = target.position + Vector3.Scale(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)), area * 0.5f);
		for (int i = 0; i < groupSetter.entities.Length; i++) {
			groupSetter.entities[i].entity.Target = newTarget;
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.DrawWireCube(target.position, area);
	}
}
