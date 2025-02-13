using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    
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
}
