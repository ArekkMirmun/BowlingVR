using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public int index;
    bool _alreadySpawned = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnHoverEnter()
    {
        print("Show weight");
        WeightUI.Instance.ShowPanel();
        WeightUI.Instance.SetWeight(rb.mass);
    }

    public void OnHoverExit()
    {
        print("Hide weight");
        WeightUI.Instance.HidePanel();
    }

    public void OnSelectedEnter()
    {
        if(_alreadySpawned) return;
        _alreadySpawned = true;
        BallSpawner.Instance.SpawnBallSelectedLane(index);
    }

}
