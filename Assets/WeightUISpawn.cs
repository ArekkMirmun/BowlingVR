using System;
using UnityEngine;

public class WeightUISpawn : MonoBehaviour
{
    
    public static WeightUISpawn Instance;

    private void Start()
    {
        Instance = this;
    }
}
