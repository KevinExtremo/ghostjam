using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemälde : TrapController
{
    public GameObject openSprite;
    public GameObject closedSprite;

    public float delayBetweenSwaps;

    private float lastSwapTime;
    private bool closed = true;

    void Awake() {
        Reset();
    }


    public override void Reset() {
        lastSwapTime = Time.time;
        closed = true;
        openSprite.SetActive(false);
        closedSprite.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSwapTime >= delayBetweenSwaps) {
            if (closed) {
                openSprite.SetActive(true);
                closedSprite.SetActive(false);
                closed = false;
                lastSwapTime = Time.time;
            } else {
                openSprite.SetActive(false);
                closedSprite.SetActive(true);
                closed = true;
                lastSwapTime = Time.time;
            }
        }
    }
}
