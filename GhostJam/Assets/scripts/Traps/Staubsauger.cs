using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staubsauger : TrapController
{
    public GameObject vacuum;
    public float speed;
    public float time;

    private float lastSwitchTime;
    private bool reverse = false;

    private PhysicsObject phyObj;

    private Vector3 startPosition;

    void Awake()
    {
        startPosition = vacuum.transform.position;
        phyObj = vacuum.GetComponent<PhysicsObject>();
        Reset();
    }

    public override void Reset() {
        lastSwitchTime = Time.time;
        vacuum.transform.position = startPosition;
        vacuum.GetComponent<SpriteRenderer>().flipX = true;
        if (reverse) {
            GameObject light = vacuum.GetComponentInChildren<Light>().gameObject;
            Vector3 oldPosition = light.transform.position;
            Vector3 newPosition = oldPosition - new Vector3(1, 0, 0);
            light.transform.position = newPosition;
        }
        Vector2 velocity = new Vector2(speed, speed);
        phyObj.SetTargetVelocity(velocity);
        reverse = false;
    }

    void Update()
    {
        if (Time.time - lastSwitchTime >= time) {
            if (reverse) {
                Vector2 velocity = new Vector2(speed, speed);
                phyObj.SetTargetVelocity(velocity);
                vacuum.GetComponent<SpriteRenderer>().flipX = true;
                GameObject light = vacuum.GetComponentInChildren<Light>().gameObject;
                Vector3 oldPosition = light.transform.position;
                Vector3 newPosition = oldPosition - new Vector3(1, 0, 0);
                light.transform.position = newPosition;
                lastSwitchTime = Time.time;
                reverse = false;
            } else {
                Vector2 velocity = new Vector2(-speed, -speed);
                phyObj.SetTargetVelocity(velocity);
                vacuum.GetComponent<SpriteRenderer>().flipX = false;
                GameObject light = vacuum.GetComponentInChildren<Light>().gameObject;
                Vector3 oldPosition = light.transform.position;
                Vector3 newPosition = oldPosition + new Vector3(1, 0, 0);
                light.transform.position = newPosition;
                lastSwitchTime = Time.time;
                reverse = true;
            }
        }
    }
}
