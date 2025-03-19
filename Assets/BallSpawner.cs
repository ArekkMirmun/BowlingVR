using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner Instance;
    public BallSpawner [] ballSpawners;
    public Transform [] ballSpawns;
    public GameObject [] ballPrefab;

    public static int SelectedLane = 0;
    public int lane;

    public bool shouldBeInstance = false;
    
    private void Awake()
    {
        if (shouldBeInstance)
        {
            Instance = this;
        }
    }
    public void SpawnLaneBalls(int laneIndex)
    {
        if (laneIndex < 0 || laneIndex >= ballSpawners.Length)
        {
            Debug.LogWarning("Invalid lane index: " + laneIndex);
            return;
        }

        ballSpawners[laneIndex].SpawnBalls();
    }
    
    public void SpawnBalls()
    {
        SelectedLane = lane;
        for (int i = 0; i < ballSpawns.Length; i++)
        {
            int ballIndex = Random.Range(0, ballPrefab.Length);
            //Instantiate making them children of this object
            GameObject ball = Instantiate(ballPrefab[ballIndex], ballSpawns[i].position, Quaternion.identity);
            ball.transform.SetParent(transform);
        }
    }

    private void SpawnBall(int index)
    {
        if (index < 0 || index >= ballSpawns.Length)
        {
            Debug.LogWarning("Invalid ball index: " + index);
            return;
        }

        int ballIndex = Random.Range(0, ballPrefab.Length);
        Instantiate(ballPrefab[ballIndex], ballSpawns[index].position, Quaternion.identity);
    }

    public void SpawnBallSelectedLane(int index)
    {
        ballSpawners[SelectedLane].SpawnBall(index);
    }
}
