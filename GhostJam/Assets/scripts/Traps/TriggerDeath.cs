using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            GameState.gameState = GameState.State.GameOver;
        }
    }
}
