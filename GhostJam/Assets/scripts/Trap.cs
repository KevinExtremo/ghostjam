using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trap : MonoBehaviour
{
    public ActionScript actionScript;

    private BoxCollider2D collider;

    void Awake() {
        collider = gameObject.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;

        if (collider == null) {
            Debug.LogError("A trap object must have a collider attached");
        }    
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            Debug.Log("The player entered a trap, this is very bad");
            actionScript.performAction(col.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}