using UnityEngine;

public class BatteryPickup : ItemPickup
{
    [SerializeField]
    private float minAmount = 10.0f;

    [SerializeField]
    private float maxAmount = 20.0f;

    private float amountToAdd;

    private void Awake()
    {
        amountToAdd = Random.Range(minAmount, maxAmount);
    }

    public override void PerformAction(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBattery playerBattery))
        {
            Debug.Log("Adding battery");
            playerBattery.AddBattery(amountToAdd);
        }
        else
        {
            Debug.Log("No battery is present");
        }

    }



}
