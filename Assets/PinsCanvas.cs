using TMPro;
using UnityEngine;

public class PinsCanvas : MonoBehaviour
{
    public static PinsCanvas Instance;
    
    [SerializeField] private TextMeshProUGUI pinsText;
    [SerializeField] private int pinsDown = 0;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public void NotifyPinDown()
    {
        pinsDown++;
        pinsText.text = "Pins: "+pinsDown.ToString();
    }
}
