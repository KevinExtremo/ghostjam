using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : TrapController
{
    public GameObject blueButton;
    public GameObject redButton;
    public GameObject greenButton;
    public GameObject yellowButton;

    private string previousButton;
    private bool finished = false;

    void Awake() {
        Reset();
    }

    public void PressButton(string color) {
        switch(color) {
            case "Grün":
                if (previousButton != "") {
                    GameState.gameState = GameState.State.GameOver;
                }
                previousButton = "Grün";
                break;
            case "Blau":
                if (previousButton != "Grün") {
                    GameState.gameState = GameState.State.GameOver;
                }
                previousButton = "Blau";
                break;
            case "Gelb":
                if (previousButton != "Blau") {
                    GameState.gameState = GameState.State.GameOver;
                }
                previousButton = "Gelb";
                break;
            case "Rot":
                if (previousButton != "Gelb") {
                    GameState.gameState = GameState.State.GameOver;
                }
                previousButton = "Rot";
                finished = true;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
        }
    }

    public bool isFinished() {
        return finished;
    }

    public override void Reset() {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        previousButton = "";
        finished = false;
    }
}
