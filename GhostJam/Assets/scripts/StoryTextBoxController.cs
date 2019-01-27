using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextBoxController : MonoBehaviour
{
    public GameObject TextField;
    public Text TextComp;
    public StoryItem storyItem { get; private set; }
    public PlayerPlatformerController playerController;
    public StoryItem InitialItem;

    public float pressDelay = 0.5f;

    private float passedTime = 0.0f;

    private void Awake()
    {
        SetNewStoryItem(InitialItem);
    }

    // Update is called once per frame
    void Update()
    {
        if (storyItem != null)
        {
            if (Input.GetAxis("Use") > 0.0f && passedTime >= pressDelay)
            {
                updateText();
                passedTime = 0.0f;
            }
            else
            {
                passedTime += Time.deltaTime;
            }
        }
    }

    private void updateText()
    {
        TextComp.text = storyItem.NextText();
        if (TextComp.text == "")
        {
            storyItem.gameObject.SetActive(false);
            storyItem = null;
            TextField.SetActive(false);
            playerController.enabled = true;
        }
    }

    public void SetNewStoryItem(StoryItem item)
    {
        storyItem = item;
        playerController.enabled = false;
        TextField.SetActive(true);
        updateText();        
    }

    public void Reset()
    {
        SetNewStoryItem(InitialItem);
    }
}
