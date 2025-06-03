using System.Collections.Generic;
using UnityEngine;

public class BatteryManager : MonoBehaviour
{
    public List<BatterySpawner> spawners; 
    public int MaxBatteriesOnMap = 4;

    private void Update()
    {
        ManageBatteries();
    }

    private void ManageBatteries()
    {
        int CurrentBatteryCount = 0;
        
        foreach (BatterySpawner spawner in spawners)
        {
            if (spawner.HasBattery)
            {
                CurrentBatteryCount++;
            }
        }
        
        if (CurrentBatteryCount < MaxBatteriesOnMap)
        {
            SpawnBatteryAtRandomSpawner();
        }
    }

    private void SpawnBatteryAtRandomSpawner()
    {
        List<BatterySpawner> EmptySpawners = new List<BatterySpawner>();

        foreach (BatterySpawner spawner in spawners)
        {
            if (!spawner.HasBattery)
            {
                EmptySpawners.Add(spawner);
            }
        }

        if (EmptySpawners.Count > 0)
        {
            int randomIndex = Random.Range(0, EmptySpawners.Count);
            EmptySpawners[randomIndex].SpawnBattery();
        }
    }
}
