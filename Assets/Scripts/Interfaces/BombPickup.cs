using UnityEngine;

public class BombPickup : ItemPickup
{
    [SerializeField]
    private float amountToReduce = 20.0f;

    public override void PerformAction(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBattery playerBattery))
        {
            Debug.Log("Reducing battery");
            playerBattery.ReduceBattery(amountToReduce);
        }
        else
        {
            Debug.Log("No battery is present");
        }
    }

}
