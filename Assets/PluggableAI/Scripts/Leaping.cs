using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Leap")]
public class Leaping : Action {

	public override void Act(StateController controller)
	{
		leap (controller);
	}

	private void leap(StateController controller)
	{
		if (controller.chaseTarget == null) {
			controller.navMeshAgent.nextPosition = GameObject.FindWithTag ("Player").transform.position + new Vector3(Random.Range(-10,10),0,Random.Range(-10,10));
		} else {
			controller.navMeshAgent.nextPosition = controller.chaseTarget.position + new Vector3(Random.Range(-10,10),0,Random.Range(-10,10));
		}
	}
}
