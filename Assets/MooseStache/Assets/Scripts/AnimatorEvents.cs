using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour {

	public void PlayerBackToNormalState () {
		var player = GetComponentInParent<Player> ();
		var fighter = GetComponentInParent<Fighter>();

		if (fighter != null)
			fighter.fsm.ChangeState(Fighter.States.Normal, MonsterLove.StateMachine.StateTransition.Overwrite);

		if (player != null ) {
			player.fsm.ChangeState (Player.States.Normal, MonsterLove.StateMachine.StateTransition.Overwrite);
		}
	}

}
