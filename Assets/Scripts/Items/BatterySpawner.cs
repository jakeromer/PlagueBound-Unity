using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    public GameObject BatteryPrefab;
    public bool HasBattery => CurrentBattery != null;
    public Vector3 SpawnOffset = Vector3.zero;
    private GameObject CurrentBattery;

    public void SpawnBattery()
    {
        if (CurrentBattery == null)
        {
            Vector3 SpawnPosition = transform.position + SpawnOffset;
            CurrentBattery = Instantiate(BatteryPrefab, SpawnPosition, Quaternion.identity);
        }
    }

    public void RemoveBattery()
    {
        if (CurrentBattery != null)
        {
            Destroy(CurrentBattery);
            CurrentBattery = null;
        }
    }

    void Awake()
    {
        SpawnBattery();
    }
}
