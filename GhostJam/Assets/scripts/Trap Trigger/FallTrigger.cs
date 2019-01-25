using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : TriggerScript
{
    public float gravityScale;

    public void performTrigger(GameObject gm) {
        
        Rigidbody2D rig = gm.AddComponent(typeof(Rigidbody2D)) as RigidBody2D;

        rig.gravityScale = this.gravityScale;
    }
}
