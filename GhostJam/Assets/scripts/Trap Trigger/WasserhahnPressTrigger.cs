using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasserhahnPressTrigger : MonoBehaviour
{
    private bool active = false;
    private bool triggered = false;

    public void Reset() {
        active = false;
        triggered = false;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            active = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active && !triggered && Input.GetAxis("Use") > 0) {
            triggered = true;
            this.gameObject.transform.parent.GetComponent<Wasserhahn>().SetFaucetActive(false);
        }
    }
}
