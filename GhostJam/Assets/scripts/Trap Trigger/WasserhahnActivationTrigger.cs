using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasserhahnActivationTrigger : MonoBehaviour
{
    private bool triggered = false;

    public void Reset() {
        triggered = false;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player" && !triggered) {
            triggered = true;
            this.gameObject.transform.parent.GetComponent<Wasserhahn>().SetFaucetActive(true);
        }
    }
}
