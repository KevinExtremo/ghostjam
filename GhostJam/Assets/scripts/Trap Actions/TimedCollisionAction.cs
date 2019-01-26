using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedCollisionAction : ActionScript
{
    public int timeUntilDeadly;

    public override void performAction(GameObject gm) {
        base.performAction(gm);

        TriggerScript trigger = GetComponentInParent<TriggerScript>();
        if ((Time.time - trigger.getTime()) >= timeUntilDeadly) {
            GameState.gameState = GameState.State.GameOver;
        }
    }
}
