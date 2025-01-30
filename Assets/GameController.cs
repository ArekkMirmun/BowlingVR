using System;
using TMPro;
using UnityEngine;

public enum GameState
{
    FirstRoll,
    SecondRoll,
    NextFrame,
    GameOver
}
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    public GameState gameState = GameState.FirstRoll;
    public TextMeshProUGUI timerText;
    public int currentFrame = 1;
    public int currentRoll = 1;
    public float roundTime = 20f;
    public float roundTimer = 0f;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ResetGame();
    }

    public void ResetPins()
    {
        //TODO: Implement new round logic
        print("Resetting pins");
    }
    
    public void ResetGame()
    {
        currentFrame = 1;
        currentRoll = 1;
        gameState = GameState.FirstRoll;
        ResetPins();
    }
    
    public void NextRoll()
    {
        if (currentRoll == 1)
        {
            currentRoll = 2;
        }
        else
        {
            currentFrame++;
            currentRoll = 1;
        }
    }
    
    public void NextFrame()
    {
        currentFrame++;
        currentRoll = 1;
    }
    
    public void NextRound()
    {
        if (currentFrame == 10)
        {
            gameState = GameState.GameOver;
        }
        else
        {
            NextFrame();
            ResetPins();
            gameState = GameState.FirstRoll;
        }
    }
    
    private void Update()
    {
        if (gameState == GameState.FirstRoll || gameState == GameState.SecondRoll)
        {
            roundTimer += Time.deltaTime;
            //Show time left on screen
            timerText.text = "Time: "+(roundTime-roundTimer).ToString("F2");
            if (roundTimer >= roundTime)
            {
                if (gameState == GameState.FirstRoll)
                {
                    gameState = GameState.SecondRoll;
                }
                else
                {
                    NextRound();
                }
                roundTimer = 0f;
            }
        }
    }
}
