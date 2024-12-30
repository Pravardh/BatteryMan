using UnityEngine;
public abstract class ItemPickup : MonoBehaviour
{
    public abstract void PerformAction(Collider collision);

    private void OnTriggerEnter(Collider other)
    {
        PerformAction(other);

        Destroy(gameObject);
    }

}
