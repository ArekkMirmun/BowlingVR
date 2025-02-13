using UnityEngine;
using UnityEngine.UI;

public class WeightUI : MonoBehaviour
{
    public static WeightUI Instance;
    public GameObject weightPanel;
    public Text weightText;
    
    
    private void Awake()
    {
        Instance = this;
    }
    public void SetWeight(float weight)
    {
        weightText.text = weight.ToString("F2");
    }

    public void HidePanel()
    {
        weightPanel.SetActive(false);
    }
    
    public void ShowPanel()
    {
        weightPanel.SetActive(true);
    }
    
}
