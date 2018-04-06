using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="PluggableAI/Decisions/Look")]
public class LookDecision : Decision {
	public float tiltAngle2 = 60f;
	public float tiltAngle1 = 30f;

	public override bool Decide(StateController controller)
	{
		bool targetVisible = Look(controller);
		return targetVisible;
	}

	public bool Look(StateController controller)
	{

		RaycastHit hit;

		Debug.DrawRay (controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.lookRange, Color.green);
		Debug.DrawRay (controller.eyes.position, controller.eyes.right.normalized * controller.enemyStats.attackRange, Color.red);
		Debug.DrawRay (controller.eyes.position, (-controller.eyes.right.normalized) * controller.enemyStats.attackRange, Color.red);
		Debug.DrawRay (controller.eyes.position, (controller.eyes.forward.normalized + controller.eyes.right.normalized) * controller.enemyStats.attackRange, Color.red);
		Debug.DrawRay (controller.eyes.position, (controller.eyes.forward.normalized -controller.eyes.right.normalized)* controller.enemyStats.attackRange, Color.red);

		if ( (Physics.SphereCast (controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.enemyStats.attackRange)||
			Physics.SphereCast (controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.right, out hit, controller.enemyStats.attackRange)||
			Physics.SphereCast (controller.eyes.position, controller.enemyStats.lookSphereCastRadius, -controller.eyes.right, out hit, controller.enemyStats.attackRange)||
			Physics.SphereCast (controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward+controller.eyes.right, out hit, controller.enemyStats.attackRange)||
			Physics.SphereCast (controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward-controller.eyes.right, out hit, controller.enemyStats.attackRange)) && hit.collider.CompareTag ("Player")) {
			controller.chaseTarget = hit.transform;
			return true;
		} else {
			return false;
		}
	}
}
