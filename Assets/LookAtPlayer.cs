using UnityEngine;
using UnityEngine.UI;

public class LookAtPlayer : MonoBehaviour
{
    
    public Camera cameraPpal;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraPpal = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraPpal.transform);
        transform.Rotate(0, 180 , 0);
    }
}
