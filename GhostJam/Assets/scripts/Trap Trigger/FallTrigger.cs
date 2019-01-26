using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : TriggerScript
{
    public float gravityScale;

    public override void performTrigger(GameObject gm) {
        
        base.performTrigger(gm);

        Rigidbody2D rig = gm.AddComponent<Rigidbody2D>();
        rig.gravityScale = 0;
        
        PhysicsObject phyObj = gm.AddComponent<PhysicsObject>();

        phyObj.gravityModifier = this.gravityScale;
    }
}
