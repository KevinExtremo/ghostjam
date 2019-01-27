using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<GameObject> traps;
    public List<StoryItem> storyItems;
    public StoryTextBoxController StoryTextBoxController;
    public static State gameState = State.Running;
    public GameObject GameOverText;
    public GameObject GameWonText;
    public GameObject Player;
    public Vector3  PlayerStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
            case State.GameOver:
                GameOverText.SetActive(true);
                Player.SetActive(false);
                if (Input.GetAxis("Submit") > 0) {
                    ResetGame();
                }
                break;
            case State.GameWon:
                GameWonText.SetActive(true);
                Player.SetActive(false);
                if (Input.GetAxis("Submit") > 0) {
                    ResetGame();
                }
                break;
            case State.Running:
                break;
        }
    }

    void ResetGame() {
        foreach(GameObject trap in traps) {
            TrapController control = trap.GetComponent<TrapController>();
            control.Reset();
        }
        foreach(var storyitem in storyItems)
        {
            storyitem.Reset();
        }
        StoryTextBoxController.Reset();

        gameState = State.Running;
        GameOverText.SetActive(false);
        GameWonText.SetActive(false);
        Player.transform.position = PlayerStartPosition;
        Player.SetActive(true);
    }

    public enum State
    {
        GameOver,
        Running,
        GameWon
    }
}
