using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public TriggerScript triggerScript;

    private BoxCollider2D collider;
    private bool triggered;

    void Awake() {
        this.collider = gameObject.GetComponent<BoxCollider2D>();
        this.triggered = false;
        if (this.collider == null) {
            Debug.LogError("A trap object must have a collider attached");
        }    
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player" && !this.triggered) {
            Debug.Log("The player triggered a trap, bad things are going to happen");
            this.triggered = true;
            triggerScript.performTrigger(this.gameObject);
        }
    }
}
