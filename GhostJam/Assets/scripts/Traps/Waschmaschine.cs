using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waschmaschine : TrapController
{
    public ParticleSystem ParticleSystem;
    public BoxCollider2D boxCollider2D;

    public override void Reset() {
        boxCollider2D.enabled = true;
        ParticleSystem.loop = true;
    }

    public void Disable()
    {
        boxCollider2D.enabled = false;
        ParticleSystem.loop = false;
    }
}
