using UnityEngine;
using System.Collections;

public struct Hit {
	public Vector3 point;
	public Vector3 velocity;
	public Vector3 normal;
}

public class Neighborhood : MonoBehaviour {

	private static int obstacleLayer = 1 << 9;
	private static int boidLayer = 1 << 10;

	public static Entity[] GetNeighbors(Vector3 position, float radius) {
		Collider[] colliders = Physics.OverlapSphere(position, radius, boidLayer);
		Entity[] neighbors = new Entity[colliders.Length];
		for (int i = 0; i < colliders.Length; i++) {
			neighbors[i] = colliders[i].GetComponent<EntityController>().entity;
		}
		return neighbors;
	}

	public static bool IsThereObstacle(Vector3 position, Vector3 velocity, out Hit hit) {
		RaycastHit hitInfo;
		if(Physics.Raycast(position, velocity.normalized, out hitInfo, velocity.magnitude, obstacleLayer)) {
			hit.point = hitInfo.point;
			hit.velocity = velocity.normalized * hitInfo.distance;
			hit.normal = hitInfo.normal;
			return true;
		}

		hit.point = Vector3.zero;
		hit.velocity = Vector3.zero;
		hit.normal = Vector3.zero;
		return false;
	}
}
