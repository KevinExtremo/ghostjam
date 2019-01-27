using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamin : TrapController
{
    public GameObject fireObject;
    public float fireDelay;

    private Light fireLight;
    
    private float lastSwapTime;
    private bool burning = false;

    private float lastAnimationTime;
    private AnimationState animationState = AnimationState.Low;

    private enum AnimationState {
        VeryLow,
        Low,
        LowMedium,
        Medium,
        MediumHigh,
        High
    };

    void Awake() {

        fireLight = fireObject.GetComponentInChildren<Light>();

    }

    public override void Reset() {
        burning = false;
        fireObject.SetActive(false);
        lastSwapTime = Time.time;

        SetAnimationState(AnimationState.Low);
        lastAnimationTime = Time.time;
    }

    private void SetAnimationState(AnimationState state) {
        switch(state) {
            case AnimationState.VeryLow:
                fireLight.range = 20;
                break;
            case AnimationState.Low:
                fireLight.range = 22;
                break;
            case AnimationState.LowMedium:
                fireLight.range = 24;
                break;
            case AnimationState.Medium:
                fireLight.range = 26;
                break;
            case AnimationState.MediumHigh:
                fireLight.range = 28;
                break;
            case AnimationState.High:
                fireLight.range = 30;
                break;
        }
    }
    
    void Update()
    {
        if (Time.time - lastSwapTime >= fireDelay) {
            if (burning) {
                burning = false;
                fireObject.SetActive(false);
                lastSwapTime = Time.time;
            } else {
                burning = true;
                fireObject.SetActive(true);
                lastSwapTime = Time.time;
            }
        }

        if (Time.time - lastAnimationTime >= .18 && burning) {
            Array values = Enum.GetValues(typeof(AnimationState));
            System.Random random = new System.Random();
            AnimationState randomState = (AnimationState)values.GetValue(random.Next(values.Length));
            SetAnimationState(randomState);
            lastAnimationTime = Time.time;
        }
    }
}
