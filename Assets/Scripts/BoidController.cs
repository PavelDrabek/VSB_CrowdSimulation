using UnityEngine;
using System.Collections;

public class BoidController : MonoBehaviour {

	public EntityController prefabEntity;
	public float timeScale;

	public Boid boid;
	public Transform Target;

	public float EntityCollisionRange;
	public float EntityViewRange;
	public float EntityViewAngle;
	public float EntitySpeed;


	public float CohesionCoef;
	public float AlignCoef;
	public float SeparationCoef;
	public float PredatorSeparationCoef;
	[Range(0,1)]
	public float Inertia;

	public int count = 30;
	public float generateInRange = 10;
	public bool generate = false;
	public bool clear = false;


	void Awake () {
		boid = new Boid();
		boid.OnEntityAdd += Boid_OnEntityAdd;
	}

	void Update () {
//		if(Target != null) {
//			boid.Target = Target.position;
//		}
//
//		boid.EntityCollisionRange = EntityCollisionRange;
//		boid.EntityViewRange = EntityViewRange;
//		boid.EntityViewAngle = EntityViewAngle;
//		boid.EntitySpeed = EntitySpeed;
//
//		boid.CohesionCoef = CohesionCoef;
//		boid.AlignCoef = AlignCoef;
//		boid.SeparationCoef = SeparationCoef;
//		boid.PredatorSeparationCoef = PredatorSeparationCoef;
//		boid.Inertia = Inertia;

		if(generate) {
			generate = false;
			for (int i = 0; i < count; i++) {
				Vector3 randomPos = Vector3.Scale(Random.insideUnitSphere * generateInRange, new Vector3(1, 0, 1));
				boid.AddEntity(new Entity(boid, randomPos));
			}
		}

		if(clear) {
			clear = false;
			boid.Entities.Clear();
		}

		boid.Update(Time.deltaTime * timeScale);
	}

	void Boid_OnEntityAdd (object sender, EntityEventArgs e)
	{
		EntityController entity = Instantiate(prefabEntity, transform) as EntityController;
		entity.SetEntity(e.entity);
	}

}
