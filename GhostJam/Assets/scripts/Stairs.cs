using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Transform targetLocation;
    public bool isBottom;
    public BoxCollider2D boxCollider;

    public static Vector3 playerTargetOffset = new Vector3(0.0f, -6.0f);

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

    public Vector3 targetPosition()
    {
        if (targetLocation == null)
        {
            Debug.LogError("No target Transform attached to the stair!!");
            return Vector3.zero;
        }

        return targetLocation.position + playerTargetOffset;
    }
}
