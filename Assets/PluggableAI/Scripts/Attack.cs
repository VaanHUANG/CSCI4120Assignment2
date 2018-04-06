using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Attack")]
public class Attack : Action {

	public override void Act(StateController controller)
	{
		Attacking (controller);
	}

	public void Attacking(StateController controller)
	{
		RaycastHit hit;

		Debug.DrawRay (controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.attackRange, Color.red);
		Debug.DrawRay (controller.eyes.position, controller.eyes.right.normalized * controller.enemyStats.attackRange, Color.red);
		Debug.DrawRay (controller.eyes.position, (-controller.eyes.right.normalized) * controller.enemyStats.attackRange, Color.red);
		Debug.DrawRay (controller.eyes.position, (controller.eyes.forward.normalized + controller.eyes.right.normalized) * controller.enemyStats.attackRange, Color.red);
		Debug.DrawRay (controller.eyes.position, (controller.eyes.forward.normalized -controller.eyes.right.normalized)* controller.enemyStats.attackRange, Color.red);

		if ((Physics.SphereCast (controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.enemyStats.attackRange)||
			Physics.SphereCast (controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.right, out hit, controller.enemyStats.attackRange)||
			Physics.SphereCast (controller.eyes.position, controller.enemyStats.lookSphereCastRadius, -controller.eyes.right, out hit, controller.enemyStats.attackRange)||
			Physics.SphereCast (controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward+controller.eyes.right, out hit, controller.enemyStats.attackRange)||
			Physics.SphereCast (controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward-controller.eyes.right, out hit, controller.enemyStats.attackRange))&&hit.collider.CompareTag ("Player"))
		{
			if(controller.CheckIfCountDownElapsed(controller.enemyStats.attackRate))
				{
					controller.tankShooting.Fire(controller.enemyStats.attackForce,controller.enemyStats.attackRate);
				}
		}
	}
}
