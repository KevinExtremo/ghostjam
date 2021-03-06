﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryItem : MonoBehaviour
{
    public List<string> StoryClues;
    private int iterator;

    private void Awake()
    {
        iterator = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerPlatformerController>().StoryTextBoxController.SetNewStoryItem(this);
        }
    }

    public string NextText()
    {
        if(StoryClues.Count -1 >= iterator)
        {
            var text = StoryClues[iterator];
            iterator++;
            return text;
        }
        else
        {
            return "";
        }
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        iterator = 0;
    }
}
