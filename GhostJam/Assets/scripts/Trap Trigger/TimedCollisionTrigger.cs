using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedCollisionTrigger : TriggerScript
{
    public float timeUntilDeadly;

    public override void performTrigger(GameObject gm) {
        base.performTrigger(gm);

        TriggerScript trigger = transform.parent.GetComponent<TriggerScript>();
        if ((Time.time - trigger.getTime()) >= timeUntilDeadly) {
            GameState.gameState = GameState.State.GameOver;
        }
    }
}
