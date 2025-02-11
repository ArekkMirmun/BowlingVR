using System;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    public GameController gameController;
    public bool ballDetected = false;

    private void Start()
    {
        gameController = GameController.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        ballDetected = true;
        gameController.BallOutOfPlay(other.gameObject);
    }
}
