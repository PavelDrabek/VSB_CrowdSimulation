using UnityEngine;
using System.Collections;

public class Neighborhood : MonoBehaviour {

	public static Entity[] GetNeighbors(Vector3 position, float radius) {
		Collider[] colliders = Physics.OverlapSphere(position, radius);
		Entity[] neighbors = new Entity[colliders.Length];
		for (int i = 0; i < colliders.Length; i++) {
			neighbors[i] = colliders[i].GetComponent<EntityController>().entity;
		}
		return neighbors;
	}
}
