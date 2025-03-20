using System.Collections;
using UnityEngine;

public class BallSpawnerController : MonoBehaviour
{
    public static BallSpawnerController Instance;
    public BallSpawner [] ballSpawners;

    public static int SelectedLane = 0;
    
    private void Awake()
    {
            Instance = this;
    }
    public void SpawnLaneBalls(int laneIndex)
    {
        if (laneIndex < 0 || laneIndex >= ballSpawners.Length)
        {
            Debug.LogWarning("Invalid lane index: " + laneIndex);
            return;
        }
        SelectedLane = laneIndex;

        StartCoroutine(ballSpawners[laneIndex].SpawnBalls());
    }

    public void SpawnBallSelectedLane(int index)
    {
        print(SelectedLane + " selected lane");
        print(index + " index");
        ballSpawners[SelectedLane].SpawnBall(index);
    }
}