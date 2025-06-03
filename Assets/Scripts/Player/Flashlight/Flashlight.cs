using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    private AudioSource FlashlightAudioSource;
    private Light2D FlashlightLight;
    private Battery FlashlightBattery;
    private AudioSource CrowInLight;
    private bool JumpscarePlayed;

    public void UpdateFlashlight(Vector3 PlayerPosition, float DelaTime)
    {
        if (Input.GetMouseButton(0) && FlashlightBattery.HasBattery()) 
        {
            if (!FlashlightLight.enabled) {FlashlightLight.enabled = true;}
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePos.z = PlayerPosition.z;
            Pointing(MousePos);
            FlashlightBattery.DrainBattery(DelaTime);
        }

        else
        {
            FlashlightLight.enabled = false;
            FlashlightAudioSource.Play();
        }
    }

    private void Pointing(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    private void OnTriggerEnter2D(Collider2D FlashlightRange)
    {
        if (FlashlightRange.CompareTag("Enemy")) 
        {
            EnemyChase Crow = FlashlightRange.GetComponent<EnemyChase>();
            if (Crow != null)
            {
                Crow.StopChasing();
                if (FlashlightLight.enabled && !JumpscarePlayed)
                {
                    CrowInLight.Play();
                    JumpscarePlayed = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D FlashlightRange)
    {
        if (FlashlightRange.CompareTag("Enemy"))
        {
            EnemyChase Crow = FlashlightRange.GetComponent<EnemyChase>();
            if (Crow != null)
            {
                if (FlashlightLight.enabled)
                {
                    Crow.StopChasing();
                    if (!JumpscarePlayed)
                    {
                        CrowInLight.Play();
                        JumpscarePlayed = true;
                    }
                }
                else
                {
                    Crow.ResumeChasing();
                    JumpscarePlayed = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D FlashlightRange)
    {
        if (FlashlightRange.CompareTag("Enemy"))
        {
            EnemyChase Crow = FlashlightRange.GetComponent<EnemyChase>();
            if (Crow != null)
            {
                Crow.ResumeChasing();
                JumpscarePlayed = false;
            }
        }
    }

    void Awake()
    {
        FlashlightLight = GetComponent<Light2D>();
        FlashlightLight.enabled = false;
        FlashlightBattery = GetComponentInParent<Battery>();
        AudioSource[] AudioClips = GetComponents<AudioSource>();
        FlashlightAudioSource = AudioClips[0];
        CrowInLight = AudioClips[1];
    }

}   