using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/SillyChasing")]
public class SillyChasing : Action {

	public override void Act(StateController controller)
	{
		sillyChasing (controller);
	}

	private void sillyChasing(StateController controller)
	{
		//Vector3 sp3 = new Vector3 (26f, 0f, 30.1f);
		controller.navMeshAgent.destination = GameObject.FindWithTag("Player").transform.position;
		controller.navMeshAgent.Resume ();
	}
}
