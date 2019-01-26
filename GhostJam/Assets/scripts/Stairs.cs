using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Transform targetLocation;
    public bool isBottom;
    public BoxCollider2D boxCollider;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            var playerController = col.GetComponent<PlayerPlatformerController>();
            playerController.CurrentStair = this;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            var playerController = col.GetComponent<PlayerPlatformerController>();
            playerController.CurrentStair = null;
        }
    }
}
