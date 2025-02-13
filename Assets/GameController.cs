using System;
using System.Collections;
using TMPro;
using UnityEngine;

public enum GameState
{
    LaneSelection,
    FirstRoll,
    SecondRoll,
    BallOutOfPlay,
    NextFrame,
    GameOver
}
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public PinsSpawn[] pinsSpawns;
    private PinsSpawn currentPinsSpawn;
    public GameObject LanesUI;
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

    private void Update()
    {
        if (gameState == GameState.FirstRoll || gameState == GameState.SecondRoll)
        {
            roundTimer += Time.deltaTime;
            //Show time left on screen
            timerText.text = "Time: "+(roundTime-roundTimer).ToString("F2");
            if (roundTimer >= roundTime)
            {
                NextRoll(); 
                roundTimer = 0f;
            }
        }
        if(gameState == GameState.BallOutOfPlay)
        {
            roundTimer += Time.deltaTime;
            //Show time left on screen
            timerText.text = "Ball Out: "+(roundTime-roundTimer).ToString("F2");
            if (roundTimer >= roundTime)
            {
                NextRoll(); 
                roundTimer = 0f;
            }
        }
    }
    
    public void ResetPins()
    {
        //TODO: Implement new round logic
        print("Resetting pins");
    }
    
    public void ResetGame()
    {
        PinsCanvas.Instance.NotifyFrame(currentFrame);
        PinsCanvas.Instance.NotifyRoll(currentRoll);
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
            PinsCanvas.Instance.NotifyRoll(currentRoll);
            currentPinsSpawn.RespawnPinsInsideTrigger();
            gameState = GameState.SecondRoll;
        }
        else
        {
            NextRound();
        }
    }
    
    public void NextFrame()
    {
        currentFrame++;
        currentRoll = 1;
        PinsCanvas.Instance.NotifyFrame(currentFrame);
        PinsCanvas.Instance.NotifyRoll(currentRoll);
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
            currentPinsSpawn.SpawnPins();
            gameState = GameState.FirstRoll;
        }
    }
    
    public void BallOutOfPlay(GameObject ball)
    {
        Destroy(ball);
        if(gameState is GameState.LaneSelection or GameState.GameOver or GameState.BallOutOfPlay) return;
        gameState = GameState.BallOutOfPlay;
        roundTimer = 15f;
    }
    
    public void SelectLane(int lane)
    {
        print("Selected lane: "+lane);
        LanesUI.SetActive(false);
        if (gameState == GameState.LaneSelection)
        {
            //Select int pinsSpawnIndex = lane-1;
            currentPinsSpawn = pinsSpawns[lane-1];
            currentPinsSpawn.SpawnPins();
            ResetGame();
        }
    }
    
}
