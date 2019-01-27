using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFuse : MonoBehaviour
{
    public List<TrapController> trapControllers;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (var trapController in trapControllers)
            {
                //TODO: disable trapController
            }
        }
    }


    // Update is called once per frame
    void Reset()
    {
        foreach(var trapController in trapControllers)
        {
            //TODO: enable trapController
        }
    }
}
