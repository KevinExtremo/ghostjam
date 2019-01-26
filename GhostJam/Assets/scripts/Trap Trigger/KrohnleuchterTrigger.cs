using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrohnleuchterTrigger : MonoBehaviour
{
    private bool triggered = false;
    private Vector3 startPosition;

    void Awake() {
        startPosition = this.gameObject.transform.position;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player" && !triggered) {
            // Dont remove, hack
            startPosition = this.gameObject.transform.position;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.transform.parent.GetComponent<PhysicsObject>().gravityModifier = 1;
            triggered = true;
        }
    }

    public void Reset() {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        triggered = false;
        this.gameObject.transform.position = startPosition;
    }
}
