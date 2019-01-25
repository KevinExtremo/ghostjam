using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAction : ActionScript
{
    public void performAction(GameObject gm) {
        GameState.gameState = GameState.State.GameOver;
    }
}
