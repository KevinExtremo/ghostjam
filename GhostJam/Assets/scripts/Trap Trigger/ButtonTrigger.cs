using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public string buttonColor;

    private bool active = false;
    
    private float lastTriggeredTime;

    void Awake() {
        lastTriggeredTime = Time.time;
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

    void Update() {
        if (Time.time - lastTriggeredTime > 1 && active && Input.GetAxis("Use") > 0) {
            lastTriggeredTime = Time.time;
            this.gameObject.transform.parent.GetComponent<ButtonPuzzle>().PressButton(buttonColor);
        }
    }
}
