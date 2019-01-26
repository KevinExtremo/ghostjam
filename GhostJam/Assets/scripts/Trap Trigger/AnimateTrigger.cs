using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTrigger : TriggerScript
{
    public override void performTrigger(GameObject gm) {

        base.performTrigger(gm);
        
        Animation anim = gm.GetComponentInChildren<Animation>();
        anim.Play();
    }
}
