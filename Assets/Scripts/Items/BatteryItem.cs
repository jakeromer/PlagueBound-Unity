using UnityEngine;

public class BatteryItem : MonoBehaviour, ICollectible
{

    [SerializeField] private string PartName;
    [SerializeField] private AudioClip PickUpNoise;
    public string Item => "Battery";

    public void OnPickup(IInventory PlayerInv, AudioSource PickUpSource)
    {
        if (PickUpNoise != null)
        {
            PickUpSource.PlayOneShot(PickUpNoise);
        }
        Flashlight PlayerLight = FindObjectOfType<Flashlight>();
        Battery PlayerBattery = PlayerLight.GetComponentInParent<Battery>();
        PlayerBattery.Recharge();
        Destroy(gameObject);
    }
}
