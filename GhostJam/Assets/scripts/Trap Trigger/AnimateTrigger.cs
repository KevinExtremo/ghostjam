using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTrigger : TriggerScript
{
    public Animation animation;

    public override void performTrigger(GameObject gm) {
        base.performTrigger(gm);

        animation.Play();
    }
}
