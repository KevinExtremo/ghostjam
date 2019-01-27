using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasserhahn : TrapController
{

    public GameObject spriteOff;
    public GameObject spriteOnOne;
    public GameObject spriteOnTwo;

    public float animationSpeed;

    public enum State {
        OFF,
        ON_1,
        ON_2
    };

    private State state;

    private bool faucetOn = false;

    private float timeSinceUpdate;

    void Awake()
    {
        Reset();
    }

    public override void Reset()
    {
        state = State.OFF;
        faucetOn = false;
        timeSinceUpdate = Time.time;

        this.gameObject.GetComponentInChildren<WasserhahnActivationTrigger>().Reset();
        this.gameObject.GetComponentInChildren<WasserhahnPressTrigger>().Reset();
    }

    void Update()
    {
        switch(state) {
            case State.OFF:
                spriteOff.SetActive(true);
                spriteOnOne.SetActive(false);
                spriteOnTwo.SetActive(false);
                break;
            case State.ON_1:
                spriteOff.SetActive(false);
                spriteOnOne.SetActive(true);
                spriteOnTwo.SetActive(false);
                break;
            case State.ON_2:
                spriteOff.SetActive(false);
                spriteOnOne.SetActive(false);
                spriteOnTwo.SetActive(true);
                break;
        }

        if (Time.time - timeSinceUpdate >= animationSpeed && faucetOn) {
            switch(state) {
                case State.ON_1:
                    state = State.ON_2;
                    timeSinceUpdate = Time.time;
                    break;
                case State.ON_2:
                    state = State.ON_1;
                    timeSinceUpdate = Time.time;
                    break;
            }
        }
    }

    public void SetFaucetActive(bool flag) {
        if (flag) {
            timeSinceUpdate = Time.time;
            state = State.ON_1;
        } else {
            timeSinceUpdate = Time.time;
            state = State.OFF;
        }
        faucetOn = flag;
    }
}
