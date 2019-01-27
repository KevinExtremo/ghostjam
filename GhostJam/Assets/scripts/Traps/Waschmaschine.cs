using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waschmaschine : TrapController
{
    public override void Reset() {
        this.gameObject.GetComponentInChildren<BoxCollider2D>().SetActive(true);
    }
}
