using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiegel : TrapController
{
    public GameObject healedMirror;
    public GameObject shatteredMirror;
    public GameObject mirrorShard;
    public float timeUntilDeadly;

    private bool triggered = false;
    private bool deadly = false;
    private float triggeredTime;
    private Vector3 shardPosition;

    void Update() {
        if (triggered && !deadly && (Time.time - triggeredTime >= timeUntilDeadly)) {
            deadly = true;
            PhysicsObject phyObj = mirrorShard.GetComponent<PhysicsObject>();
            BoxCollider2D box = mirrorShard.GetComponent<BoxCollider2D>();
            box.enabled = true;
            shardPosition = mirrorShard.transform.position;
            phyObj.gravityModifier = 1;
        }
    }

    public override void Reset() {
        triggered = false;
        deadly = false;
        healedMirror.SetActive(true);
        shatteredMirror.SetActive(false);
        mirrorShard.SetActive(false);
        BoxCollider2D rootBox = this.GetComponent<BoxCollider2D>();
        BoxCollider2D shardBox = mirrorShard.GetComponent<BoxCollider2D>();
        rootBox.enabled = true;
        shardBox.enabled = false;
        triggeredTime = Time.time;
        Destroy(mirrorShard.GetComponent<PhysicsObject>());
        PhysicsObject phyObj = mirrorShard.AddComponent<PhysicsObject>();
        phyObj.gravityModifier = 0;
        mirrorShard.transform.position = shardPosition;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (!triggered) {
            healedMirror.SetActive(false);
            shatteredMirror.SetActive(true);
            mirrorShard.SetActive(true);
            triggeredTime = Time.time;
            BoxCollider2D rootBox = this.GetComponent<BoxCollider2D>();
            BoxCollider2D shardBox = mirrorShard.GetComponent<BoxCollider2D>();
            rootBox.enabled = false;
            shardBox.enabled = false;
            triggered = true;
        }
    }
}
