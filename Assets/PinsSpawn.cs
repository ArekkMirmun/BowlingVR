using UnityEngine;

public class PinsSpawn : MonoBehaviour
{
    public Pin pinPrefab;
    public GameObject[] pinsSpawn;
    public Pin[] pins;
    public int[] pinsDown;
    public bool[] pinsInsideTrigger; // Boolean array for tracking pins inside trigger

    public void SpawnPins()
    {
        ClearPins(false);
        Debug.Log("Spawning all pins");

        pins = new Pin[pinsSpawn.Length];
        pinsInsideTrigger = new bool[pinsSpawn.Length]; // Reset and set all to true

        for (int i = 0; i < pinsSpawn.Length; i++)
        {
            SpawnSpecificPin(i);
        }
    }

    public void SpawnSpecificPin(int index)
    {
        if (index < 0 || index >= pinsSpawn.Length)
        {
            Debug.LogWarning("Invalid pin index: " + index);
            return;
        }

        Pin pinGO = Instantiate(pinPrefab, pinsSpawn[index].transform.position, pinPrefab.transform.rotation);
        pinGO.pinIndex = index;
        pinGO.transform.SetParent(pinsSpawn[index].transform);
        pins[index] = pinGO;

        pinsInsideTrigger[index] = true; // Mark pin as inside the trigger
    }

    public void ClearPins(bool clearPinsInsideTrigger)
    {
        Debug.Log("Clearing pins");
        if (pins == null || pins.Length == 0) return;

        for (int i = 0; i < pinsSpawn.Length; i++)
        {
            foreach (Transform child in pinsSpawn[i].transform)
            {
                Destroy(child.gameObject);
            }
            pins[i] = null;
        }

        if (clearPinsInsideTrigger) return;
        
        // Reset all pins to true (assuming all start inside trigger)
        if (pinsInsideTrigger != null)
        {
            for (int i = 0; i < pinsInsideTrigger.Length; i++)
            {
                pinsInsideTrigger[i] = true;
            }
        }
    }

    public void RespawnPinsInsideTrigger()
    {
        Debug.Log("Respawning pins inside trigger");

        ClearPins(true);

        bool hasPinsInside = false;

        for (int i = 0; i < pinsInsideTrigger.Length; i++)
        {
            if (pinsInsideTrigger[i])
            {
                SpawnSpecificPin(i);
                hasPinsInside = true;
            }
        }

        if (!hasPinsInside)
        {
            Debug.Log("No pins inside trigger, spawning all pins");
            SpawnPins();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Pin pin) && other.gameObject.CompareTag("Pin"))
        {
            Debug.Log("Pin exited trigger: " + pin.pinIndex);
            PinsCanvas.Instance.NotifyPinDown();
            other.gameObject.tag = "Untagged";

            // Set the corresponding boolean to false
            pinsInsideTrigger[pin.pinIndex] = false;
        }
    }
}
