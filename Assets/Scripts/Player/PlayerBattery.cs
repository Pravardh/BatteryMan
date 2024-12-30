using UnityEngine;
using UnityEngine.UI;

public class PlayerBattery : MonoBehaviour
{
    [SerializeField]
    private float maxBattery = 100.0f;

    [SerializeField]
    private float reduceAmount = 10.0f;

    [SerializeField]
    private float waitTimeInSeconds = 8.0f;

    [SerializeField]
    private Slider batteryProgressBar;

    private float currentBattery = 0.0f;

    private float elapsedTime = 0.0f;
    private void Awake()
    {
        currentBattery = maxBattery;

        ReloadUI();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= waitTimeInSeconds)
        {
            ReduceBattery();
            elapsedTime = 0.0f;
        }

    }

    public void ReduceBattery(float magnitude = -1)
    {
        Debug.Log("Reducing player battery");
        if (magnitude == -1)
            currentBattery -= reduceAmount;

        else
            currentBattery -= magnitude;

        ReloadUI();
    }

    public void AddBattery(float magnitude)
    {
        currentBattery = Mathf.Clamp(currentBattery + magnitude, 0.0f, maxBattery);
        ReloadUI();
    }

    private void ReloadUI()
    {
        batteryProgressBar.value = currentBattery / 100.0f;
    }
}
