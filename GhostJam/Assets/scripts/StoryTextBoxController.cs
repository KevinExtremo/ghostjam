using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextBoxController : MonoBehaviour
{
    public Text TextField;
    public StoryItem StoryItem { get; private set; }
    public PlayerPlatformerController playerController;
    public StoryItem InitialItem;

    private void Awake()
    {
        StoryItem = InitialItem;
    }

    // Update is called once per frame
    void Update()
    {
        if (StoryItem != null)
        {
            if (Input.GetAxis("Use") > 0.0f)
            {
                TextField.text = StoryItem.NextText();
                if (TextField.text == "")
                {
                    StoryItem = null;
                    TextField.enabled = false;
                    playerController.enabled = true;
                }
            }
        }
    }

    public void SetNewStoryItem(StoryItem item)
    {
        StoryItem = item;
        playerController.enabled = false;
    }

    public void Reset()
    {
        StoryItem = InitialItem;
    }
}
