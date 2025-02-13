using TMPro;
using UnityEngine;

public class PinsCanvas : MonoBehaviour
{
    public static PinsCanvas Instance;
    
    [SerializeField] private TextMeshProUGUI pinsText;
    [SerializeField] private TextMeshProUGUI rollText;
    [SerializeField] private TextMeshProUGUI frameText;
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

    public void NotifyRoll(int roll)
    {
        rollText.text = "Roll: "+roll;
    }
    
    public void NotifyFrame(int frame)
    {
        frameText.text = "Frame: "+frame;
    }
}
