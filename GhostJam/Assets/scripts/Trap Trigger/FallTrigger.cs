using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : TriggerScript
{
    public float gravityScale;

    public override void performTrigger(GameObject gm) {
        
        Rigidbody2D rig = gm.AddComponent<Rigidbody2D>();

        rig.gravityScale = this.gravityScale;
    }
}
