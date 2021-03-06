﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFocus : MonoBehaviour
{
    [Tooltip("The transform of the player that shall be in focus")]
    public Transform PlayerTransform;
    [Tooltip("The transform of the player that shall be in focus")]
    public PlayerPlatformerController PlatformerController;
    [Tooltip("The position Offset of the Camera to the Player in Focus")]
    public Vector3 Offset = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerTransform == null)
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var offset = Offset;
        if(PlatformerController.isCrawling)
        {
            offset -= PlatformerController.heightDiffCrawling;
        }
        transform.position = PlayerTransform.position + offset;
    }
}
