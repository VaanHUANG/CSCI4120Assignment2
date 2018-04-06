using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/State")]
public class State : ScriptableObject {

	public Action[] actions;
	public Transition[] transitions;
	public Color sceneGizmoColor=Color.grey;

	// Update is called once per frame
	public void UpdateState(StateController controller){
		DoActions (controller);
		checkTransitions (controller);
	}

	private void DoActions(StateController controller){
		for (int i = 0; i < actions.Length; i++) {
			actions [i].Act (controller);
		}
	}

	private void checkTransitions(StateController controller)
	{
		for (int i = 0; i < transitions.Length; i++) 
		{
			bool decisionSuceeded = transitions [i].decision.Decide (controller);

			if (decisionSuceeded) {
				controller.TransitionToState(transitions[i].trueState);
			}
			else{
				controller.TransitionToState(transitions[i].falseState);
			}
		}

	}
}
