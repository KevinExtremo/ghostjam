using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAction : ActionScript
{
    public override void performAction(GameObject gm) {
        base.performAction(gm);
        
        GameState.gameState = GameState.State.GameOver;
    }
}
