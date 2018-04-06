using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/ActiveStateDecision")]
public class ActiveStateDecision : Decision {

	public override bool Decide(StateController controller)
	{
		bool chaseTargetIsActive = controller.chaseTarget.gameObject.activeSelf & (Vector3.Distance(controller.chaseTarget.transform.position,controller.navMeshAgent.transform.position)<=controller.enemyStats.lookRange);
		return chaseTargetIsActive;
	}
}
