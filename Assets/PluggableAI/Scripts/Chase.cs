using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="PluggableAI/Actions/Chase")]
public class Chase : Action {

	public override void Act(StateController controller)
	{
		ChaseTarget (controller);
	}

	private void ChaseTarget(StateController controller)
	{
		controller.navMeshAgent.destination = controller.chaseTarget.position;
		controller.navMeshAgent.Resume ();

	}
}
