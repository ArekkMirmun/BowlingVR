using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Transform [] ballSpawns;
    public GameObject [] ballPrefab;
    public Transform ballTarget;

    public IEnumerator SpawnBalls()
    {
        for (int i = 0; i < ballSpawns.Length; i++)
        {
            SpawnBall(i);
            //wait 1 second before spawning the next ball
            yield return new WaitForSeconds(1);
        }
    }

    public void SpawnBall(int index)
    {
        GameObject ballGO = Instantiate(ballPrefab[index], ballSpawns[index].position, Quaternion.identity);
        //add impulse force to the ball to reach ball target
        ballGO.GetComponent<Rigidbody>().AddForce((ballTarget.position - ballSpawns[index].position).normalized * 500);
    }
}
