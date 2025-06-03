using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battery : MonoBehaviour
{
    private float MaxBattery = 100f;
    private float BatteryDepletion = 5f;
    private float CurrentBattery;
    [SerializeField] private Slider BatterySlider;

    public bool HasBattery()
    {
        return CurrentBattery > 0;
    }
    
    public void KillBattery()
    {
        CurrentBattery = 0f;
        UpdateBatteryUI();
    }

    public void DrainBattery(float DeltaTime)
    {
        CurrentBattery -= BatteryDepletion * DeltaTime;
        CurrentBattery = Mathf.Clamp(CurrentBattery, 0, MaxBattery);
        UpdateBatteryUI();
    }

    public void Recharge()
    {
        CurrentBattery = MaxBattery;
        UpdateBatteryUI();
    }

    public float GetBattery()
    {
        return (CurrentBattery / MaxBattery) * 100f;
    }

    private void UpdateBatteryUI()
    {
        if (BatterySlider != null)
        {
            BatterySlider.value = CurrentBattery / MaxBattery;
        }
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial") { CurrentBattery = 0f; }
        else 
        {
            CurrentBattery = MaxBattery;
        }
        UpdateBatteryUI();
    }

}
