using UnityEngine;

public class CollectionController : MonoBehaviour
{
    private IInventory PlayerInv;
    private AudioSource PickUpSource;

    public void Init(IInventory inventory)
    {
        PlayerInv = inventory;
        PickUpSource = GetComponent<AudioSource>();
        if (PickUpSource == null)
        {
            PickUpSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            ICollectible CollectedItem = other.GetComponent<ICollectible>();
            if (CollectedItem != null)
            {
                CollectedItem.OnPickup(PlayerInv, PickUpSource);
            }
        }
    }
}
