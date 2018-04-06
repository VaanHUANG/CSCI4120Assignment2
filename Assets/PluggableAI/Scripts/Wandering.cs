using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Wandering")]
public class Wandering : Action {

	//public float duration;
	//bool moving = true;
	//float wait          = 10f; //wait this much time
	//float waitedTime      = 0f;
	//public List<GameObject> WanderPointList;

	public override void Act(StateController controller)
	{
		float randomX = Random.Range (-20, 20);
		float randomZ = Random.Range (-20, 20);

		/*float walktime=0f;
		if (walktime <= duration && moving) {
			controller.navMeshAgent.transform.Translate(new Vector3 (randomX, 0, randomZ)*Time.deltaTime);
			walktime += Time.deltaTime;
		} else {
			moving = false;
			waitedTime =0f;
		}
		if (waitedTime < wait && !moving) {
			waitedTime += Time.deltaTime;
		}
		else if(!moving){
			moving = true;
			walktime = 0f;
			randomX = Random.Range (-5, 5);
			randomZ = Random.Range (-5, 5);
		}*/

		/*if (controller.navMeshAgent.transform.position == controller.navMeshAgent.destination) {
			randomX = Random.Range (-20, 20);
			randomZ = Random.Range (-20, 20);
			controller.navMeshAgent.destination = new Vector3 (randomX, 0, randomZ);
		}*/
	controller.navMeshAgent.destination = controller.wayPointList [controller.nextWayPoint].position+ new Vector3(randomX,0,randomZ);
		controller.navMeshAgent.Resume ();
		if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) {
			controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
		}
	}
}
