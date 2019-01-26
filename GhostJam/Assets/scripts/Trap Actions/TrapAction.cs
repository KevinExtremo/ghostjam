using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrapAction : MonoBehaviour
{
    public ActionScript actionScript;

    private BoxCollider2D collider;

    void Awake() {
        collider = gameObject.GetComponent<BoxCollider2D>();;

        if (collider == null) {
            Debug.LogError("A trap object must have a collider attached");
        }    
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.gameObject.tag == "Player") {
            Debug.Log("The player entered a trap, this is very bad");
            actionScript.performAction(col.gameObject);
        }
    }
}