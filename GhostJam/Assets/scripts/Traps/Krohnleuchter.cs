using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krohnleuchter : TrapController
{
    public GameObject spriteOne;
    public GameObject spriteTwo;
    public GameObject spriteThree;
    public PhysicsObject phyObj;
    public GameObject trigger;

    private BoxCollider2D boxOne;
    private BoxCollider2D boxTwo;
    private BoxCollider2D boxThree;

    private Vector3 positionOne;
    private Vector3 positionTwo;
    private Vector3 positionThree;

    private Vector3 lightPosition;

    private bool triggered = false;

    private bool animationStart = false;
    private float animationStartTime;

    private bool animationFinished = false;

    void Awake() {
        positionOne = spriteOne.gameObject.transform.position;
        positionTwo = spriteTwo.gameObject.transform.position;
        positionThree = spriteThree.gameObject.transform.position;

        lightPosition = this.gameObject.GetComponentInChildren<Light>().gameObject.transform.position;

        boxOne = spriteOne.GetComponent<BoxCollider2D>();
        boxTwo = spriteTwo.GetComponent<BoxCollider2D>();
        boxThree = spriteThree.GetComponent<BoxCollider2D>();

        Reset();
    }

    void Update() {
        if (phyObj.gravityModifier > 0) {
            triggered = true;
        }

        if (triggered && !animationStart) {
            if (phyObj.isGrounded()) {
                this.gameObject.GetComponentInChildren<Light>().enabled = false;
                animationStart = true;
                animationStartTime = Time.time;
                spriteOne.SetActive(false);
                boxOne.enabled = false;
                boxTwo.enabled = true;
                spriteTwo.SetActive(true);
            }
        }

        if (animationStart && !animationFinished) {
            if (Time.time - animationStartTime > .2) {
                boxTwo.enabled = false;
                boxThree.enabled = true;
                spriteTwo.SetActive(false);
                spriteThree.SetActive(true);
                animationFinished = true;
            }
        }
    }

    public override void Reset() {

        spriteOne.gameObject.transform.position = positionOne;
        spriteTwo.gameObject.transform.position = positionTwo;
        spriteThree.gameObject.transform.position = positionThree;

        spriteOne.SetActive(true);
        spriteTwo.SetActive(false);
        spriteThree.SetActive(false);

        boxOne.enabled = true;
        boxTwo.enabled = false;
        boxThree.enabled = false;
        
        Destroy(this.gameObject.GetComponent<PhysicsObject>());
        phyObj = this.gameObject.AddComponent<PhysicsObject>();
        phyObj.gravityModifier = 0;

        trigger.GetComponent<KrohnleuchterTrigger>().Reset();

        animationStart = false;
        animationFinished = false;
        animationStartTime = Time.time;

        Light light = this.gameObject.GetComponentInChildren<Light>();
        light.enabled = true;
        light.gameObject.transform.position = lightPosition;
    }
}
