using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFuse : MonoBehaviour
{
    public Waschmaschine washingmachine;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            washingmachine.Disable();
        }
    }


    // Update is called once per frame
    void Reset()
    {
        washingmachine.Reset();
    }
}
