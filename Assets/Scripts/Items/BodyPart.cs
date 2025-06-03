using UnityEngine;

public class BodyPart : MonoBehaviour, ICollectible
{
    [SerializeField] private string PartName;
    [SerializeField] private AudioClip PickUpNoise;
    public string Item => PartName;

    public void OnPickup(IInventory PlayerInv, AudioSource PickUpSource)
    {
        if (PickUpNoise != null)
        {
            PickUpSource.PlayOneShot(PickUpNoise);
        }
        PlayerInv.AddItem(this);
        Destroy(gameObject);
    }

    private void Awake()
    {
        if (string.IsNullOrEmpty(PartName))
        {
            PartName = gameObject.name;
        }
    }
}
