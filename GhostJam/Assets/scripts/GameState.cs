using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<GameObject> traps;
    public List<StoryItem> storyItems;
    public static State gameState = State.Running;
    public GameObject GameOverText;
    public GameObject GameWonText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
            case State.GameOver: //todo
                break;
            case State.GameWon:  //todo
                break;
            case State.Running:  //todo
                break;
        }
    }

    public enum State
    {
        GameOver,
        Running,
        GameWon
    }
}
