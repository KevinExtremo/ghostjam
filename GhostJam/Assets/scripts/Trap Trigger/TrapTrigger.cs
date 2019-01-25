using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public TriggerScript triggerScript;

    private BoxCollider2D collider;

    void Awake() {
        collider = gameObject.GetComponent<BoxCollider2D>();

        if (collider == null) {
            Debug.LogError("A trap object must have a collider attached");
        }    
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            Debug.Log("The player triggered a trap, bad things are going to happen");
            GameObject spriteObject = GetComponentInChildren<SpriteRenderer>().gameObject;
            if (spriteObject == null) {
                Debug.LogError("A trap was triggered that apparently has no sprite object :( please fix");
            }
            triggerScript.performTrigger(spriteObject);
        }
    }
}
