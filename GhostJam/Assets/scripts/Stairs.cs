using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Transform targetLocation;
    public bool isBottom;
    public BoxCollider2D boxCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var col = collision.collider.gameObject;
        if(col.CompareTag("Player"))
        {
            var playerController = col.GetComponent<PlayerPlatformerController>();
            playerController.CurrentStair = this;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var col = collision.collider.gameObject;
        if (col.CompareTag("Player"))
        {
            var playerController = col.GetComponent<PlayerPlatformerController>();
            playerController.CurrentStair = null;
        }
    }
}
