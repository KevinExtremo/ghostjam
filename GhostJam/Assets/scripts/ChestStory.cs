using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestStory : MonoBehaviour
{
    public StoryItem closed;
    public StoryItem open;
    public GameObject Ghost;
    public Chest chest;
    public StoryItem key;

    private PlayerPlatformerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && player.enabled)
        {
            GameState.gameState = GameState.State.GameWon;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(key.gameObject.active)
            {
                collision.GetComponent<PlayerPlatformerController>().StoryTextBoxController.SetNewStoryItem(closed);
            }
            else
            {
                collision.GetComponent<PlayerPlatformerController>().StoryTextBoxController.SetNewStoryItem(open);
                Ghost.SetActive(true);
                player = collision.GetComponent<PlayerPlatformerController>();
            }
        }
    }
}
